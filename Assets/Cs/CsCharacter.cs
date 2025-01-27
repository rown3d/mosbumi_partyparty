using UnityEngine;
using UnityEngine.UI;

public class CsCharacter : MonoBehaviour {

    // movement
    Rigidbody m_pRigidbody;

    // input
    float m_flInputX;
    float m_flInputY;
    bool m_bInputFart;
    bool m_bInputFartReleased;

    // game logic
    int m_nFart;
    int m_nScore;
    float m_flBoundaryDeath;
    bool m_bGameOver;

    // rendering
    Texture m_pTexture;

    // parameters
    [SerializeField] float m_flBounceSpeed;
    [SerializeField] float m_flSpeedMultiplier;
    [SerializeField] float m_flBoundaryDeathOffset;

    // references
    [SerializeField] CsGame m_pGame;
    [SerializeField] CsCamera m_pCamera;
    [SerializeField] Texture m_pTextureUp;
    [SerializeField] Texture m_pTextureDown;
    [SerializeField] Texture m_pTextureSideUp;
    [SerializeField] Texture m_pTextureSideDown;
    [SerializeField] AudioSource m_pAudioFart1;
    [SerializeField] AudioSource m_pAudioFart2;
    [SerializeField] AudioSource m_pAudioFart3;
    [SerializeField] CsBubbleFart m_pBubbleFartPrefab;
    [SerializeField] Image m_pFartBar1;
    [SerializeField] Image m_pFartBar2;
    [SerializeField] Image m_pFartBar3;
    [SerializeField] Image m_pFartBar4;
    [SerializeField] Image m_pScorePanelOutline;
    [SerializeField] Image m_pScorePanel;
    [SerializeField] Text m_pScoreText;
    [SerializeField] Text m_pScoreFinalText;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {

        // get rigidbody
        m_pRigidbody = GetComponent<Rigidbody>();

        // get texture from material from renderer component
        m_pTexture = GetComponent<MeshRenderer>().material.mainTexture;

        // set fart amount to 0
        m_nFart = 0;

        // set score to 0
        m_nScore = 0;

        // set score ui
        m_pScoreText.text = "0";
        m_pScoreFinalText.text = "final score: 0";
        m_pScorePanel.rectTransform.sizeDelta = new Vector2(m_pScoreText.preferredWidth, 40.0f);
        m_pScorePanelOutline.rectTransform.sizeDelta = new Vector2(m_pScoreText.preferredWidth + 10, 50.0f);

        // set the death boundary
        m_flBoundaryDeath = -m_flBoundaryDeathOffset;

        // set local game over status
        m_bGameOver = false;

        // reset inputs
        m_flInputX = 0.0f;
        m_flInputY = 0.0f;
        m_bInputFart = false;
        m_bInputFartReleased = true;

    }

    // update is called once per frame
    void Update() {

        // get movement inputs
        m_flInputX = Input.GetAxisRaw("Horizontal");
        m_flInputY = Input.GetAxisRaw("Vertical");

        // set fart released input
        if (m_flInputY > -0.5f) {

            // fart input has been released
            m_bInputFartReleased = true;
        }

        // set fart input
        if (m_flInputY < -0.5f && m_bInputFartReleased == true) {

            // fart next time update fixed is called
            m_bInputFart = true;
            m_bInputFartReleased = false;
        }
    }

    // update fixed is called 50 times per second
    void FixedUpdate() {

        // horizontal movement
        m_pRigidbody.linearVelocity = new Vector3(
            m_flInputX * m_flSpeedMultiplier,
            m_pRigidbody.linearVelocity.y,
            m_pRigidbody.linearVelocity.z
        );

        // maximum fart threshold
        if (m_nFart < 2999) {

            // increate amount of fart
            m_nFart += 1;
        }

        // bubble up (fart)
        if (m_bInputFart == true && m_nFart > 750) {

            // spend 750 fart units
            m_nFart -= 750;

            // instantiate bubble fart
            CsBubbleFart pBubbleFart = Instantiate(m_pBubbleFartPrefab, transform.position, transform.rotation);

            // give bubble fart name
            pBubbleFart.name = "bubble fart";

            // give it a reference to the pop sound effect
            pBubbleFart.AudioPopSet(m_pAudioFart1);

            // apply speed to fart bubble
            pBubbleFart.m_flSpeedX += m_pRigidbody.linearVelocity.x*0.01f;

            // choose random fart sound
            switch (Random.Range(0,2)) {

                // play the sound
                case 0: m_pAudioFart2.Play(); break;
                case 1: m_pAudioFart3.Play(); break;
                default: break;
            }

            // launch piggy
            Launch();
        }

        // trigger stage generation, generate more bubbles when high enough
        m_pGame.TriggerBubblesAdd(transform.position.y);

        // check if we crossed death boundary
        if (transform.position.y < m_flBoundaryDeath && m_bGameOver == false) {

            // game over
            m_pGame.GameOver();

            // set local game over status
            m_bGameOver = true;
        }

        // update animation
        AnimationUpdate();

        // update fart ui
        m_pFartBar1.rectTransform.sizeDelta = new Vector2((Mathf.Clamp(m_nFart,    0.0f,  750.0f)          )*(180.0f / 750.0f), 20.0f);
        m_pFartBar2.rectTransform.sizeDelta = new Vector2((Mathf.Clamp(m_nFart,  750.0f, 1500.0f) -  750.0f)*(180.0f / 750.0f), 20.0f);
        m_pFartBar3.rectTransform.sizeDelta = new Vector2((Mathf.Clamp(m_nFart, 1500.0f, 2250.0f) - 1500.0f)*(180.0f / 750.0f), 20.0f);
        m_pFartBar4.rectTransform.sizeDelta = new Vector2((Mathf.Clamp(m_nFart, 2250.0f, 3000.0f) - 2250.0f)*(180.0f / 750.0f), 20.0f);

        // reset fart input
        m_bInputFart = false;
    }

    // update animations
    void AnimationUpdate() {

        // character is falling down
        if (m_pRigidbody.linearVelocity.y < 0) {

            // character is not horizontally moving
            if (m_pRigidbody.linearVelocity.x == 0) {

                // set character sprite
                m_pTexture = m_pTextureDown;

            // character is horizontally moving
            } else {

                // set character sprite
                m_pTexture = m_pTextureSideDown;

                // set the x scale of characeter
                transform.localScale = new Vector3(-Mathf.Sign(m_pRigidbody.linearVelocity.x), 1.0f, 1.0f);
            }

        // moving up
        } else {

            // character is not horizontally movingbubble
            if (m_pRigidbody.linearVelocity.x == 0) {

                // set character sprite
                m_pTexture = m_pTextureUp;

            // character is horizontally moving
            } else {

                // set character spritebubble
                m_pTexture = m_pTextureSideUp;

                // set the x scale of characeter
                transform.localScale = new Vector3(-Mathf.Sign(m_pRigidbody.linearVelocity.x), 1.0f, 1.0f);
            }
        }

        // set main texture on material
        GetComponent<MeshRenderer>().material.mainTexture = m_pTexture;
    }

    // call this function when the character needs to be launched
    void Launch() {

        // launch the piggy up
        m_pRigidbody.linearVelocity = new Vector3(
            m_pRigidbody.linearVelocity.x,
            m_flBounceSpeed,
            m_pRigidbody.linearVelocity.z
        );
    }

    // this function is called when the bounce event fires and returns if the character was able to bounce
    public bool BubbleBounce() {

        // only bounce when falling down
        if (m_pRigidbody.linearVelocity.y > 0) {

            // no bounce was done, exit this function
            return false;
        }

        // bounce the character up
        Launch();

        // set new camera target
        m_pCamera.m_flTargetY = transform.position.y;

        // set the new death boundary
        m_flBoundaryDeath = m_pCamera.transform.position.y - m_pCamera.CameraOffsetGet() - m_flBoundaryDeathOffset;

        // bounce completed
        return true;
    }

    // this function is called when the character collects a coin
    public void CoinCollect() {

        // increase score
        m_nScore += 1;

        // update ui
        m_pScoreText.text = m_nScore.ToString();
        m_pScoreFinalText.text = "final score: " + m_nScore.ToString();
        m_pScorePanel.rectTransform.sizeDelta = new Vector2(m_pScoreText.preferredWidth, 40.0f);
        m_pScorePanelOutline.rectTransform.sizeDelta = new Vector2(m_pScoreText.preferredWidth + 10, 50.0f);
    }
}
