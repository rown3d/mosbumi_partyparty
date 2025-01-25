using UnityEngine;

public class CsBubble : MonoBehaviour {

    // references
    [SerializeField] AudioSource m_pAudioPop;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {
        
    }

    // update is called once per frame
    void Update() {
        
    }

    // this function fires when a character enters the CsBubble
    void OnTriggerEnter(Collider pCollider) {

        // fire the bounce function on the character
        pCollider.GetComponent<CsCharacter>().Bounce();

        // play sound effect at random pitch
        m_pAudioPop.pitch = Random.Range(0.8f, 1.2f);
        m_pAudioPop.Play();
    }

    // this function sets the reference to the pop sound effect
    public void AudioPopSet(AudioSource audioPop) {

        // set reference to supplied argument
        m_pAudioPop = audioPop;
    }
}
