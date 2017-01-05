using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class LeaderboardData {
    public int[] data = new int[10];
    public string[] dataName = new string[10];
}

public class Leaderboard : MonoBehaviour {
    LeaderboardData leaderBoardData = new LeaderboardData();
    string leaderboardPath = "/leaderboard.dat";
    [SerializeField]
    Text[] texts;
    CanvasGroup canvasGroup;
    [SerializeField]
    GameObject highScore;
    [SerializeField]
    Text highScoreText;
    [SerializeField]
    Text highScoreTextGame;
    [SerializeField]
    GameObject leaderboardEntry;
    [SerializeField]
    Transform leaderboardContent;

    void Start() {
        leaderboardPath = Application.persistentDataPath + leaderboardPath;
        canvasGroup = GetComponent<CanvasGroup>();
        Load();
        UpdateText();
    }

    public void Show() {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    void Load() {
        if(!File.Exists(leaderboardPath))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        using(FileStream fs = File.Open(leaderboardPath, FileMode.Open)) {
            leaderBoardData = bf.Deserialize(fs) as LeaderboardData;
        }
    }

    void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        using(FileStream fs = File.Open(leaderboardPath, FileMode.OpenOrCreate)) {
            bf.Serialize(fs, leaderBoardData);
        }
    }

    public void UpdateScore(int newScore) {
        int i = 0;

        while(i < leaderBoardData.data.Length && leaderBoardData.data[i] >= newScore)
            i++;

        if(i == 0) {
            highScore.SetActive(true);
            highScoreText.text = "NEW HIGH SCORE!!!\n" + newScore;
        }
            
        UpdateScore(newScore, i);

        UpdateText();
    }

    void UpdateScore(int newScore, int i) {
        if(i >= leaderBoardData.data.Length)
            return;

        int temp = leaderBoardData.data[i];
        leaderBoardData.data[i] = newScore;
        UpdateScore(temp, ++i);
    }

    void UpdateText() {
        highScoreTextGame.text = "HIGH SCORE " + leaderBoardData.data[0];

        for(int i = 0; i < leaderBoardData.data.Length; i++) {
            texts[i].text = (i + 1) + " - " + leaderBoardData.data[i];
        }

    }

    public void OnDestroy() {
        Save();
    }

    public void OnDisable() {
        Save();
    }

    public void OnApplicationQuit() {
        Save();
    }
}
