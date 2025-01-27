using UnityEngine;

public class CsCamera : MonoBehaviour {

    [HideInInspector] public float m_flTargetY;

    // parameters
    [SerializeField] float m_flCameraOffset;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {
        
        // default camera height
        m_flTargetY = transform.position.y;
    }

    // update is called once per frame
    void Update() {
        
        // check if target is above current position
        if (m_flTargetY > transform.position.y - m_flCameraOffset) {

            // smooth scrolling
            float flTargetPosition = m_flTargetY + m_flCameraOffset;
            float flTargetDistance = flTargetPosition - transform.position.y;
            //float flTargetSpeed = Mathf.Sqrt(flTargetDistance);
            //float flTargetSpeed = Mathf.Pow(flTargetDistance, 2.0f)/10.0f;
            float flTargetSpeed = Mathf.Sqrt(flTargetDistance) + Mathf.Pow(flTargetDistance, 2.0f)/10.0f;

            // change the camera position
            transform.position = new Vector3(0.0f, transform.position.y + flTargetSpeed * Time.deltaTime, -10.0f);
        }
    }

    // call this function when you need m_flCameraOffset
    public float CameraOffsetGet() {

        // return the camera offset
        return m_flCameraOffset;
    }

    // update fixed is called 50 times per second
    /*void FixedUpdate() {

        // check if target is above current position
        if (m_flTargetY > transform.position.y - m_flCameraOffset) {

            // smooth scrolling
            float flTargetPosition = m_flTargetY + m_flCameraOffset;
            float flTargetDistance = flTargetPosition - transform.position.y;
            float flTargetSpeed = Mathf.Sqrt(flTargetDistance);

            // change the camera position
            transform.position = new Vector3(0.0f, transform.position.y + flTargetSpeed, -10.0f);
        }
    }*/
}
