using UnityEngine;
using System.Collections;

public class DestroyerTrigger : MonoBehaviour {
    public void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Trap"))
            GameController.instance.health -= 10;

        Destroy(collision.gameObject);
    }
}
