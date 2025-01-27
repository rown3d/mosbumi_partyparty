using UnityEngine;

public class CsGame : MonoBehaviour {

    [SerializeField] CsBubble m_pBubblePrefab;
    [SerializeField] CsCoin m_pCoinPrefab;
    [SerializeField] string[] m_iLore;

    // references
    [SerializeField] GameObject m_pGameOver;
    [SerializeField] AudioSource m_pAudioPop;
    [SerializeField] AudioSource m_pAudioCoin1;
    [SerializeField] AudioSource m_pAudioCoin2;
    [SerializeField] AudioSource m_pAudioCoin3;
    [SerializeField] AudioSource m_pAudioHazard;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {

        // put down a bunch of random bubbles
        BubblesAdd(20, -8.0f, 8.0f,  -4.0f,  4.0f);
        BubblesAdd(18, -8.0f, 8.0f,   4.0f,  12.0f);
        BubblesAdd(16, -8.0f, 8.0f,  12.0f,  20.0f);
        BubblesAdd(14, -8.0f, 8.0f,  20.0f,  28.0f);
        BubblesAdd(12, -8.0f, 8.0f,  28.0f,  36.0f);
        BubblesAdd(10, -8.0f, 8.0f,  36.0f,  44.0f);
        BubblesAdd( 9, -8.0f, 8.0f,  44.0f,  52.0f);
        BubblesAdd( 8, -8.0f, 8.0f,  52.0f,  60.0f);
        BubblesAdd( 7, -8.0f, 8.0f,  60.0f,  68.0f);
        BubblesAdd( 6, -8.0f, 8.0f,  68.0f,  76.0f);
        BubblesAdd( 5, -8.0f, 8.0f,  76.0f,  84.0f);
        BubblesAdd( 4, -8.0f, 8.0f,  84.0f,  92.0f);
        BubblesAdd( 3, -8.0f, 8.0f,  92.0f, 100.0f);
        BubblesAdd( 2, -8.0f, 8.0f, 100.0f, 108.0f);
        BubblesAdd( 1, -8.0f, 8.0f, 108.0f, 116.0f);
    }

    // add a new section of bubbles
    public void BubblesAdd(int nBubbleAmount, float flBoundLeft, float flBoundRight, float flBoundDown, float flBoundUp) {

        // put down a bunch of random bubbles
        for (int nIndex = 0; nIndex <= nBubbleAmount; nIndex += 1) {

            // instantiate a bubble
            CsBubble pBubble = Instantiate(m_pBubblePrefab);

            // give it a name
            pBubble.name = "bubble";

            // give it a random position
            pBubble.transform.position = new Vector3(Random.Range(flBoundLeft, flBoundRight), Random.Range(flBoundDown, flBoundUp), 0.0f);

            // give it a reference to the pop sound effect
            pBubble.AudioPopSet(m_pAudioPop);
        }

        // instantiate a coin
        CsCoin pCoin = Instantiate(m_pCoinPrefab);

        // give it a name
        pCoin.name = "coin";

        // give it a random position
        pCoin.transform.position = new Vector3(Random.Range(flBoundLeft, flBoundRight), Random.Range(flBoundDown, flBoundUp), 0.0f);

        // give it a reference to the pop sound effect
        pCoin.AudioCoinSet(m_pAudioCoin1, m_pAudioCoin2, m_pAudioCoin3);
    }

    // calling this function ends the game
    public void GameOver() {

        // play the sound effect
        m_pAudioHazard.Play();

        // enable the game over object
        m_pGameOver.SetActive(true);

        // find all characters
        foreach (CsCharacter pCharacter in GameObject.FindObjectsOfType<CsCharacter>()) {

            // stop all character movement
            pCharacter.enabled = false;
            pCharacter.gameObject.GetComponent<Rigidbody>().constraints =
                 RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
                 RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX |
                 RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
