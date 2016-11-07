using UnityEngine;
using UnityEngine.EventSystems;

public class Disabler : MonoBehaviour, IPointerClickHandler {
    public float disableDelay = 3.0f;

    float timer;

    public void OnEnable() {
        timer = 0;
    }

    void Update() {
        if(timer > disableDelay)
            gameObject.SetActive(false);

        timer += Time.deltaTime;
    }

    public void OnPointerClick(PointerEventData eventData) {
        gameObject.SetActive(false);
    }
}
