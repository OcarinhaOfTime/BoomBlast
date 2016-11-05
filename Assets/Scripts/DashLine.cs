using UnityEngine;
using System.Collections;

public class DashLine : MonoBehaviour {
    public float speed = 2;
    LineRenderer lr;
	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
        lr.sortingLayerName = "Foreground";
        //lr.sortingOrder = 999;
    }

    // Update is called once per frame
    void FixedUpdate () {
        lr.material.SetTextureOffset("_MainTex", new Vector2(Time.time * -speed, 0));
        //lr.material.SetTextureScale("_MainTex", new Vector2(, 0));
    }
}
