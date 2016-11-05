using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour {
    [SerializeField]ProjectileDragging projectile;
    [SerializeField]float spawnDelay = 2.0f;

    void Start () {
        Spawn();
    }

    public void Spawn() {
        var inst = Instantiate(projectile);
        inst.transform.position = projectile.transform.position;
        inst.gameObject.SetActive(true);
        inst.onRelease.AddListener(() => StartCoroutine(SpawnRoutine()));
    }

    IEnumerator SpawnRoutine() {
        yield return new WaitForSeconds(spawnDelay);
        Spawn();
    }
}
