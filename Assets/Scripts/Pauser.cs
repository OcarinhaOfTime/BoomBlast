using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {
    public void OnEnable() {
        Time.timeScale = 0;
    }

    public void OnDisable() {
        Time.timeScale = 1;
    }
}
