using UnityEngine;

public class CsCharacter : MonoBehaviour {

    Rigidbody m_pRigidbody;
    //MeshRenderer m_pRenderer;
    //Material m_pMaterial;
    Texture m_pTexture;
    float m_flInputX;

    // parameters
    [SerializeField] float m_flBounceSpeed;
    [SerializeField] float m_flSpeedMultiplier;

    // references
    [SerializeField] Texture m_pTextureUp;
    [SerializeField] Texture m_pTextureDown;
    [SerializeField] Texture m_pTextureSideUp;
    [SerializeField] Texture m_pTextureSideDown;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {

        // get rigidbody
        m_pRigidbody = GetComponent<Rigidbody>();

        // get texture from material from renderer component
        //m_pMaterial = GetComponent<MeshRenderer>().material;
        m_pTexture = GetComponent<MeshRenderer>().material.mainTexture;
    }

    // update is called once per frame
    void Update() {

        // get the inputs
        m_flInputX = Input.GetAxisRaw("Horizontal");
    }

    // update fixed is called 50 times per second
    void FixedUpdate() {

        // horizontal movement
        m_pRigidbody.linearVelocity = new Vector3(
            m_flInputX * m_flSpeedMultiplier,
            m_pRigidbody.linearVelocity.y,
            m_pRigidbody.linearVelocity.z
        );

        // update animation
        AnimationUpdate();
    }

    // update animations
    void AnimationUpdate() {

        // debug
        //Debug.Log("animations");

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

            // character is not horizontally moving
            if (m_pRigidbody.linearVelocity.x == 0) {

                // set character sprite
                m_pTexture = m_pTextureUp;

            // character is horizontally moving
            } else {

                // set character sprite
                m_pTexture = m_pTextureSideUp;

                // set the x scale of characeter
                transform.localScale = new Vector3(-Mathf.Sign(m_pRigidbody.linearVelocity.x), 1.0f, 1.0f);
            }
        }

        // set main texture on material
        GetComponent<MeshRenderer>().material.mainTexture = m_pTexture;
    }

    // this function is called when the bounce event fires
    public void Bounce() {

        // debug
        //Debug.Log("bounce");

        // bounce the character up
        //m_pRigidbody.linearVelocity = m_flBounceSpeed * transform.up;
        //m_pRigidbody.linearVelocity.y = ;
        m_pRigidbody.linearVelocity = new Vector3(
            m_pRigidbody.linearVelocity.x,
            m_flBounceSpeed,
            m_pRigidbody.linearVelocity.z
        );
    }
}
