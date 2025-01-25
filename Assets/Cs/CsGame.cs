using UnityEngine;

public class CsGame : MonoBehaviour {

    [SerializeField] CsBubble m_pBubblePrefab;
    [SerializeField] string[] m_iLore;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {

        // put down a bunch of random bubbles
        for (int nIndex = 0; nIndex <= 20; nIndex += 1) {

            // instantiate a bubble
            CsBubble pBubble = Instantiate(m_pBubblePrefab);

            // give it a name
            pBubble.name = "bubble";

            // give it a random position
            pBubble.transform.position = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f), 0.0f);
        }
    }
}
