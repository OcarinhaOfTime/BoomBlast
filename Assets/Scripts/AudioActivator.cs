using UnityEngine;
using System.Collections;

public class AudioActivator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetFloat("Volume", 1);
	}
}
