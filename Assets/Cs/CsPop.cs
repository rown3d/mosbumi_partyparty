using UnityEngine;

public class CsPop : MonoBehaviour {

    // start is called once before the first execution of update after the monobehaviour is created
    void Start() {

            // flip pop effect randomly
            float flScaleX = Mathf.Sign(Random.Range(-1.0f, 1.0f));
            transform.localScale = new Vector3(flScaleX, 1.0f, 1.0f);
    }

    // update is called once per frame
    void Update() {
        
    }
}
