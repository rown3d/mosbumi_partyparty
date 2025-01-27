using UnityEngine;

public class CsPopFart : CsPop {

    [SerializeField] ParticleSystem m_pCloudPrefab;

    // this function is called when the gameobject is instantiated
    void Awake() {

        // instantiate a cloud
        Instantiate(m_pCloudPrefab, transform.position, transform.rotation);
    }
}
