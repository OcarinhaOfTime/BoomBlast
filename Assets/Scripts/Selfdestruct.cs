using UnityEngine;
using System.Collections;

public class Selfdestruct : MonoBehaviour {
    public float delay = 1;

    float timer = 0;
	
	void Update () {
        if(timer > delay)
            Destroy(gameObject);

        timer += Time.deltaTime;
	}
}
