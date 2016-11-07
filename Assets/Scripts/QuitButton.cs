using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour {
	void Start () {
        GetComponent<Button>().onClick.AddListener(Application.Quit);
    }
}
