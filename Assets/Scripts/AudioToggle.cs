using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class AudioToggle : MonoBehaviour {
    public static UnityEvent onToggle = new UnityEvent();
    public Sprite on;
    public Sprite off;

    private Image image;
    private Text text;

    void Start () {
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
        GetComponent<Button>().onClick.AddListener(Toggle);

        if(PlayerPrefs.HasKey("Volume")) {
            UpdateGFX();
        } else {
            PlayerPrefs.SetFloat("Volume", 1);
        }
	}

    void Toggle() {
        if(PlayerPrefs.GetFloat("Volume") > 0) {
            PlayerPrefs.SetFloat("Volume", 0);
        } else {
            PlayerPrefs.SetFloat("Volume", 1);
        }

        UpdateGFX();
        onToggle.Invoke();
    }

    void UpdateGFX() {
        if(off != null)
            UpdateSprite();
        else
            UpdateText();
    }

    void UpdateSprite() {
        if(PlayerPrefs.GetFloat("Volume") > 0) {
            image.sprite = on;
        } else {
            image.sprite = off;
        }
    }

    void UpdateText() {
        if(PlayerPrefs.GetFloat("Volume") > 0) {
            text.text = "Sound ON";
        } else {
            text.text = "Sound OFF";
        }
    }
}
