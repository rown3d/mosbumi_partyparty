using UnityEngine;

public class CsBubbleFart : CsBubble {

    [HideInInspector] public float m_flSpeedX;
    [HideInInspector] public float m_flSpeedY;

    // parameters
    [SerializeField] float m_flDeacceleration;

    // references
    //[SerializeField] ParticleSystem m_pPopFartPrefab;

    // this function is called when the gameobject is instantiated
    void Awake() {

        // set default values
        m_flSpeedX = 0.0f;
        m_flSpeedY = -0.05f;

        // change the pop prefab into a pop fart prefab
        //m_pPopPrefab = m_pPopFartPrefab;
    }

    // this function is called 50 times per second
    void FixedUpdate() {

        // decrease speed. if speed deacceleration overshoots 0.0f, make sure to set speed to 0.0f
        m_flSpeedX -= Mathf.Abs(m_flSpeedX) > m_flDeacceleration ? Mathf.Sign(m_flSpeedX)*m_flDeacceleration : m_flSpeedX;
        m_flSpeedY -= Mathf.Abs(m_flSpeedY) > m_flDeacceleration ? Mathf.Sign(m_flSpeedY)*m_flDeacceleration : m_flSpeedY;

        // translation, move the bubble
        transform.position = new Vector3(
            transform.position.x + m_flSpeedX,
            transform.position.y + m_flSpeedY,
            transform.position.z
        );
    }
}
