using UnityEngine;

public class CsAmbience : MonoBehaviour {

    [SerializeField] AudioSource m_pAudioOst;
    [HideInInspector] public int m_nProgress;

    // this function is called when the object in instantiated
    void Awake() {

        // carry this object over to the game scene
        DontDestroyOnLoad(this.gameObject);

        // keep track of the progression
        m_nProgress = 0;
    }

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {
        
    }

    // update is called once per frame
    void Update() {
        
    }

    // call this function when the ost needs to start
    public void OstPlay() {

        // play the ost
        m_pAudioOst.Play();
    }
}
