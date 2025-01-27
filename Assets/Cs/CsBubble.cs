using UnityEngine;

public class CsBubble : MonoBehaviour {

    // references
    [SerializeField] AudioSource m_pAudioPop;
    [SerializeField] ParticleSystem m_pPopPrefab;
    //[SerializeField] protected ParticleSystem m_pPopPrefab;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {
        
    }

    // update is called once per frame
    void Update() {
        
    }

    // this function fires when a character enters the CsBubble
    void OnTriggerEnter(Collider pCollider) {

        // collide with the bubble
        OnBubbleCollision(pCollider);
    }

    // this function fires when a character is inside the CsBubble
    void OnTriggerStay(Collider pCollider) {

        // collide with the bubble
        OnBubbleCollision(pCollider);
    }

    void OnBubbleCollision(Collider pCollider) {

        // fire the bounce function on the character
        bool bBounce = pCollider.GetComponent<CsCharacter>().BubbleBounce();

        // character actually bounced
        if (bBounce == true) {

            // play sound effect at random pitch
            m_pAudioPop.pitch = Random.Range(0.8f, 1.2f);
            m_pAudioPop.Play();

            // create pop effect
            Instantiate(m_pPopPrefab, transform.position, transform.rotation);

            // destory bubble
            Destroy(gameObject);
        }
    }

    // this function sets the reference to the pop sound effect
    public void AudioPopSet(AudioSource audioPop) {

        // set reference to supplied argument
        m_pAudioPop = audioPop;
    }
}
