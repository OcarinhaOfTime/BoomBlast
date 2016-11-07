using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadOnTap : MonoBehaviour {
    public string sceneName;

	void Start () {
        if(string.IsNullOrEmpty(sceneName))
            GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        else
            GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(sceneName));
    }
}
