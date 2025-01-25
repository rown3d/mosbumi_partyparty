using UnityEngine;

public class CsCamera : MonoBehaviour {

    [HideInInspector] public float m_pTargetY;

    // parameters
    [SerializeField] float m_flCameraOffset;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {
        
        // default camera height
        m_pTargetY = transform.position.y;
    }

    // update is called once per frame
    void Update() {
        
    }

    // update fixed is called 50 times per second
    void FixedUpdate() {

        // check if target is above current position
        if (m_pTargetY > transform.position.y - m_flCameraOffset) {

            // change the camera position
            transform.position = new Vector3(0.0f, m_pTargetY + m_flCameraOffset, -10.0f);
        }
    }
}
