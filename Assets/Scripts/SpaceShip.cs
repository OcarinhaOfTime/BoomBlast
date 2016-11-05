using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {
    public float speed = 1;
    float boundary;

    bool facingLeft;

    void Start() {
        boundary = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight)).x;
    }

    void FixedUpdate() {
        if(facingLeft && transform.position.x < -boundary || !facingLeft && transform.position.x > boundary) {
            facingLeft = !facingLeft;
            speed *= -1;
        }            

        transform.position += new Vector3(speed, 0, 0);
    }
}
