using UnityEngine;

public class CsCharacter : MonoBehaviour {

    Rigidbody m_pRigidbody;

    // parameters
    [SerializeField] float m_flBounceSpeed;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {

        // get the rigidbody
        m_pRigidbody = GetComponent<Rigidbody>();
    }

    // update is called once per frame
    void Update() {

    }

    // this function is called when the bounce event fires
    public void Bounce() {

        // debug
        Debug.Log("bounce");

        // bounce the character up
        m_pRigidbody.linearVelocity = m_flBounceSpeed * transform.up;
    }
}
