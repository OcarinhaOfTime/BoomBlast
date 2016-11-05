using UnityEngine;
using System.Collections;

public class Disabler : MonoBehaviour {
    public float disableDelay = 3.0f;

    float timer;

    public void OnMouseDown() {
        gameObject.SetActive(false);
    }

    void Update() {
        if(timer > disableDelay)
            gameObject.SetActive(false);

        timer += Time.deltaTime;
    }
}
