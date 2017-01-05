using UnityEngine;
using UnityEngine.EventSystems;

public class Disabler : MonoBehaviour, IPointerClickHandler {
    public float disableDelay = 3.0f;
    public bool disableOnTap = true;

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
        if(disableOnTap)
            gameObject.SetActive(false);
    }
}
