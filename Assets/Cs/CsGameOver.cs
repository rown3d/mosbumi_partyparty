using UnityEngine;
using UnityEngine.UI;

public class CsGameOver : MonoBehaviour {

    [SerializeField] Image m_pLorePanel;
    [SerializeField] Text m_pLoreText;
    [SerializeField] CsGame m_pGame;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {

        // progress is stored in ambience
        // note to self: not very logical
        CsAmbience pAmbience = GameObject.FindObjectOfType<CsAmbience>();
        
        // null check
        if (pAmbience != null) {

            // get the lore string
            m_pLoreText.text = m_pGame.m_iLore[pAmbience.m_nProgress];

            // update ui
            m_pLorePanel.rectTransform.sizeDelta = new Vector2(m_pLoreText.preferredWidth + 10, 50.0f);

            // increate the progression
            pAmbience.m_nProgress += 1;

            // loop the story
            if (pAmbience.m_nProgress >= m_pGame.m_iLore.Length) {

                // reset progress
                pAmbience.m_nProgress = 0;
            }
        }
    }

    // update is called once per frame
    void Update() {

        // key is pressed
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Confirm") || Input.GetButtonDown("Jump")) {

            // restart the game
            Application.LoadLevel(1);
        }
    }
}
