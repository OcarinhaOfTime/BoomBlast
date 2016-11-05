﻿using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour {
    public static SFXManager instance;
    public AudioClip explosion;
    public AudioClip shoot;

    private AudioSource audioSource;

    void Awake () {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
	
    public static void PlayExplosion() {
        instance.audioSource.clip = instance.explosion;
        instance.audioSource.Play();
    }

    public static void PlayShoot() {
        instance.audioSource.clip = instance.shoot;
        instance.audioSource.Play();
    }
}
