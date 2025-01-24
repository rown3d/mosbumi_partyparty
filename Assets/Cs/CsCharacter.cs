using UnityEngine;

public class CsCharacter : MonoBehaviour {

    Rigidbody m_pRigidbody;
    float m_flInputX;

    // parameters
    [SerializeField] float m_flBounceSpeed;
    [SerializeField] float m_flSpeedMultiplier;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {

        // get the rigidbody
        m_pRigidbody = GetComponent<Rigidbody>();
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
    }

    // this function is called when the bounce event fires
    public void Bounce() {

        // debug
        Debug.Log("bounce");

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
