using UnityEngine;

public class CsMain : MonoBehaviour {

    [SerializeField] CsAmbience m_pAmbience;

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {
        
    }

    // update is called once per frame
    void Update() {

        // key is pressed
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Confirm") || Input.GetButtonDown("Jump")) {

            // start the ost
            m_pAmbience.OstPlay();

            // go to the game
            Application.LoadLevel(1);
        }
    }
}
