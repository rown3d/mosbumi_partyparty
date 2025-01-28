using UnityEngine;

public class CsBackground : MonoBehaviour {

    [SerializeField] CsCamera m_pCamera;
    Material m_pMaterial;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {

        // get a reference to the material
        m_pMaterial = GetComponent<MeshRenderer>().material;
    }

    // update is called once per frame
    void Update() {
        
        // debug
        //Debug.Log(1.0f - (m_pCamera.transform.position.y / 420.0f));

        // fade away background as height increases
        m_pMaterial.color = new Color(0.6226414f, 0.0f, 0.0f, 1.0f - (m_pCamera.transform.position.y / 420.0f));
    }
}
