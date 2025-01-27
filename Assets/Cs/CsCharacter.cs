using UnityEngine;

public class CsCharacter : MonoBehaviour {

    Rigidbody m_pRigidbody;
    //MeshRenderer m_pRenderer;
    //Material m_pMaterial;
    Texture m_pTexture;
    float m_flInputX;
    float m_flInputY;
    bool m_bInputFart;
    bool m_bInputFartReleased;
    float m_flBoundaryDeath;
    bool m_bGameOver;

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

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {

        // get rigidbody
        m_pRigidbody = GetComponent<Rigidbody>();

        // get texture from material from renderer component
        m_pTexture = GetComponent<MeshRenderer>().material.mainTexture;

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

        // horizontal movementbubble
        m_pRigidbody.linearVelocity = new Vector3(
            m_flInputX * m_flSpeedMultiplier,
            m_pRigidbody.linearVelocity.y,
            m_pRigidbody.linearVelocity.z
        );

        // bubble up (fart)
        if (m_bInputFart == true) {

            // instantiate bubble fart
            CsBubbleFart pBubbleFart = Instantiate(m_pBubbleFartPrefab, transform.position, transform.rotation);

            // give bubble fart name
            pBubbleFart.name = "bubble fart";

            // give it a reference to the pop sound effect
            pBubbleFart.AudioPopSet(m_pAudioFart1);

            // apply speed to fart bubble
            pBubbleFart.m_flSpeedX += m_pRigidbody.linearVelocity.x*0.01f;
            //pBubbleFart.m_flSpeedY += m_pRigidbody.linearVelocity.y;

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

        // check if we crossed death boundary
        if (transform.position.y < m_flBoundaryDeath && m_bGameOver == false) {

            // game over
            m_pGame.GameOver();

            // set local game over status
            m_bGameOver = true;
        }

        // update animation
        AnimationUpdate();

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
    public bool Bounce() {

        // only bounce when falling down
        if (m_pRigidbody.linearVelocity.y > 0) {

            // no bounce was done, exit this function
            return false;
        }

        // bounce the character up
        Launch();

        // set new camera target
        m_pCamera.m_pTargetY = transform.position.y;

        // set the new death boundary
        m_flBoundaryDeath = transform.position.y - m_flBoundaryDeathOffset;

        // bounce completed
        return true;
    }
}
