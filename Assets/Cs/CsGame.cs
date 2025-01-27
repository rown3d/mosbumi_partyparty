using UnityEngine;

public class CsGame : MonoBehaviour {

    [SerializeField] CsBubble m_pBubblePrefab;
    [SerializeField] CsCoin m_pCoinPrefab;
    public string[] m_iLore;

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
        BubblesSectionAdd(20, -4.0f);
    }

    // put down a section of bubbles with specific parameters
    void BubblesSectionAdd(int nBubbleAmount, float flSectionHeight) {

        // put down a bunch of random bubbles
        BubblesAdd(nBubbleAmount -  0, -8.0f, 8.0f, flSectionHeight +   0.0f, flSectionHeight +   8.0f);
        BubblesAdd(nBubbleAmount -  2, -8.0f, 8.0f, flSectionHeight +   8.0f, flSectionHeight +  16.0f);
        BubblesAdd(nBubbleAmount -  4, -8.0f, 8.0f, flSectionHeight +  16.0f, flSectionHeight +  24.0f);
        BubblesAdd(nBubbleAmount -  6, -8.0f, 8.0f, flSectionHeight +  24.0f, flSectionHeight +  32.0f);
        BubblesAdd(nBubbleAmount -  8, -8.0f, 8.0f, flSectionHeight +  32.0f, flSectionHeight +  40.0f);
        BubblesAdd(nBubbleAmount - 10, -8.0f, 8.0f, flSectionHeight +  40.0f, flSectionHeight +  48.0f);
        BubblesAdd(nBubbleAmount - 11, -8.0f, 8.0f, flSectionHeight +  48.0f, flSectionHeight +  52.0f);
        BubblesAdd(nBubbleAmount - 12, -8.0f, 8.0f, flSectionHeight +  56.0f, flSectionHeight +  64.0f);
        BubblesAdd(nBubbleAmount - 13, -8.0f, 8.0f, flSectionHeight +  64.0f, flSectionHeight +  72.0f);
        BubblesAdd(nBubbleAmount - 14, -8.0f, 8.0f, flSectionHeight +  72.0f, flSectionHeight +  80.0f);
        BubblesAdd(nBubbleAmount - 15, -8.0f, 8.0f, flSectionHeight +  80.0f, flSectionHeight +  88.0f);
        BubblesAdd(nBubbleAmount - 16, -8.0f, 8.0f, flSectionHeight +  88.0f, flSectionHeight +  96.0f);
        BubblesAdd(nBubbleAmount - 17, -8.0f, 8.0f, flSectionHeight +  96.0f, flSectionHeight + 104.0f);
        BubblesAdd(nBubbleAmount - 18, -8.0f, 8.0f, flSectionHeight + 104.0f, flSectionHeight + 112.0f);
        BubblesAdd(nBubbleAmount - 19, -8.0f, 8.0f, flSectionHeight + 112.0f, flSectionHeight + 120.0f);
    }

    // add a new section of bubbles
    void BubblesAdd(int nBubbleAmount, float flBoundLeft, float flBoundRight, float flBoundDown, float flBoundUp) {

        // make sure the amount is larger than 0
        if (nBubbleAmount < 1) {

            // set the bubble amount to 1
            nBubbleAmount = 1;
        }

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

    // character call this function to trigger generation of the next secion of bubbles
    public void TriggerBubblesAdd(float flTriggerHeight) {

        // section 2
        if (flTriggerHeight > 116.0f) {

            // add a vertical section of bubbles
            BubblesSectionAdd(19, 116.0f);
        }
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
