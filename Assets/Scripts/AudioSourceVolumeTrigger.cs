using UnityEngine;
using System.Collections;

public class AudioSourceVolumeTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
	}
}
