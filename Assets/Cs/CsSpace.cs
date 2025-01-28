using UnityEngine;

public class CsSpace : MonoBehaviour {

    [SerializeField] CsCamera m_pCamera;
    Material m_pMaterial;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {

        // get a reference to the material
        m_pMaterial = GetComponent<MeshRenderer>().material;
    }

    // update is called once per frame
    void Update() {

        // fade in background as height increases
        //m_pMaterial.color = new Color(1.0f, 1.0f, 1.0f, ((m_pCamera.transform.position.y / 210.0f) - 210.0f) / 420.0f);
        //m_pMaterial.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Clamp((((m_pCamera.transform.position.y / 420.0f) - 0.5f)*2), 0.0f, 1.0f));
        //m_pMaterial.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Clamp(((m_pCamera.transform.position.y / 420.0f) - 0.5f), 0.0f, 0.5f));
        m_pMaterial.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Clamp(((m_pCamera.transform.position.y / 420.0f) - 1.0f), 0.0f, 0.3f));
    }
}
