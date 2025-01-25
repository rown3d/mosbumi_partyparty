using UnityEngine;

public class CsCoin : MonoBehaviour {

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {
        
    }

    // update is called once per frame
    void Update() {
        
    }

    // this function fires when a character enters the CsBubble
    void OnTriggerEnter(Collider pCollider) {

        // fire the bounce function on the character
        // pCollider.GetComponent<CsCharacter>().Bounce();

        // destory game object
        Destroy(gameObject);
    }
}
