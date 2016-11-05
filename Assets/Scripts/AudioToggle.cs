using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioToggle : MonoBehaviour {
    public Sprite on;
    public Sprite off;

    private Image image;

    void Start () {
        image = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(Toggle);

        if(PlayerPrefs.HasKey("Volume")) {
            UpdateSprite();
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

        UpdateSprite();
    }

    void UpdateSprite() {
        if(PlayerPrefs.GetFloat("Volume") > 0) {
            image.sprite = on;
        } else {
            image.sprite = off;
        }
    }
}
