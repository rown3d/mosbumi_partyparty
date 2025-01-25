using UnityEngine;

public class CsCoin : MonoBehaviour {

    // references
    [SerializeField] AudioSource m_pAudioCoin1;
    [SerializeField] AudioSource m_pAudioCoin2;
    [SerializeField] AudioSource m_pAudioCoin3;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {
        
    }

    // update is called once per frame
    void Update() {
        
    }

    // this function fires when a character enters the CsBubble
    void OnTriggerEnter(Collider pCollider) {

        // destory game object
        Destroy(gameObject);

        // choose random coin sound
        switch (Random.Range(0,3)) {

            // play the sound
            case 0: m_pAudioCoin1.Play(); break;
            case 1: m_pAudioCoin2.Play(); break;
            case 2: m_pAudioCoin3.Play(); break;
            default: break;
        }
    }

    // this function sets references to the coin sound effect
    public void AudioCoinSet(AudioSource audioCoin1, AudioSource audioCoin2, AudioSource audioCoin3) {

        // set reference to supplied arguments
        m_pAudioCoin1 = audioCoin1;
        m_pAudioCoin2 = audioCoin2;
        m_pAudioCoin3 = audioCoin3;
    }
}
