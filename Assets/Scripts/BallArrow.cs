using UnityEngine;
using System.Collections;

public class BallArrow : MonoBehaviour {
    [SerializeField]
    GameObject explosionPrefab;

    public void OnCollisionEnter2D(Collision2D collision) {
        var middlePoint = (collision.transform.position + transform.position) / 2;
        var inst = Instantiate(explosionPrefab);
        inst.transform.position = middlePoint;
        inst.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        GameController.instance.score += 10;
        SFXManager.PlayExplosion();
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
