using UnityEngine;

public class CsGameOver : MonoBehaviour {

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {
        
    }

    // update is called once per frame
    void Update() {

        // key is pressed
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Confirm") || Input.GetButtonDown("Jump")) {

            // restart the game
            Application.LoadLevel(0);
        }
    }
}
