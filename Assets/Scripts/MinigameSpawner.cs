﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MinigameSpawner : MonoBehaviour {
    public int firstBurst = 1;
    public GameObject[] itens;
    public float spawnDelay = 2;
    public float spawnDelayVariance = 1;
    public float clalengeIncreaseDelay = 30;
    public float clalengeIncreaseFactor = 2;
    public Text levelText;

    float timer;
    float challengeTimer;
    int level { get { return (int)(Time.time / clalengeIncreaseDelay) + 1; } }
    //float spawnBoundary;

    void Start () {
        //spawnBoundary = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight)).x;
        for(int i = 0; i < firstBurst; i++)
            Spawn();
    }
	
	void Update () {
        if(timer > spawnDelay) {
            float realSpawnDelay = spawnDelay + Random.Range(-spawnDelayVariance, spawnDelayVariance);
            timer = 0;
            Spawn();
        } else {
            timer += Time.deltaTime;
        }

        levelText.text = "LEVEL " + level;
        Challenger();
    }

    void Challenger() {
        if(challengeTimer > clalengeIncreaseDelay) {
            challengeTimer = 0;
            foreach(var go in itens) {
                go.GetComponent<Rigidbody2D>().drag /= clalengeIncreaseFactor;
            }
            //levelText.text = "LEVEL " + level;
            Debug.Log("level up " + level);
            SFXManager.PlayLevelup();
        }

        challengeTimer += Time.deltaTime;
    }

    void Spawn() {
        var instance = Instantiate(itens[Random.Range(0, itens.Length)]);
        instance.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        instance.SetActive(true);
    }
}