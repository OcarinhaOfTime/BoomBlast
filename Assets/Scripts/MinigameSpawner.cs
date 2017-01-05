using UnityEngine;
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
    public Sprite[] backgrounds;
    public SpriteRenderer background;

    float timer;
    float challengeTimer;
    int level = 1;
    //float spawnBoundary;

    void Start () {
        level = 1;
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

        Challenger();
    }

    void Challenger() {
        if(challengeTimer > clalengeIncreaseDelay) {
            challengeTimer = 0;
            level++;
            levelText.text = "LEVEL " + level;
            SFXManager.PlayLevelup();
            background.sprite = backgrounds[(level-1) % backgrounds.Length];
        }

        challengeTimer += Time.deltaTime;
    }

    void Spawn() {
        var instance = Instantiate(itens[Random.Range(0, itens.Length)]);
        instance.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        instance.SetActive(true);
    }
}