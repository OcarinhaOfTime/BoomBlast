using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public int maxHealth = 250;

    public int health {
        get {
            return _health;
        }
        set {
            _health = value;
            healthSlider.value = _health / (float)maxHealth;
            if(_health <= 0) {
                gameOverPanel.SetActive(true);
                leaderboard.UpdateScore(score);
                leaderboard.Show();
            }
        }
    }
    public int score {
        get {
            return _score;
        }
        set {
            _score = value;
            coinsText.text = "SCORE " + _score;
        }
    }

    int _score;
    int _health;

    [SerializeField]
    Text coinsText;
    [SerializeField]
    Slider healthSlider;
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    Leaderboard leaderboard;

    void Awake() {
        instance = this;
        health = maxHealth;
        score = 0;
    }
}
