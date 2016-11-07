using UnityEngine;
using System.Collections;

public class PointerWrapper : MonoBehaviour {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
    Vector2 delta;
    Vector3 mouseLastPosition;
    static PointerWrapper instance;

    void Awake() {
        instance = this;
    }

    void Update() {
        delta = Input.mousePosition - mouseLastPosition;
        mouseLastPosition = Input.mousePosition;
    }
#endif
    public static Vector3 PointerPosition() {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Input.GetTouch(0).position;
#else
        return Input.mousePosition;
#endif
    }

    public static bool IsPointerOverGameObject() {
#if UNITY_EDITOR
        return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
#else
        return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(0);
#endif
    }

    public static bool IsPointerDown() {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
#else
        return Input.GetMouseButtonDown(0);
#endif
    }

    public static bool IsPointerPressed() {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;
#else
        return Input.GetMouseButton(0);
#endif
    }

    public static bool IsPointerUp() {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
#else
        return Input.GetMouseButtonUp(0);
#endif
    }

    public static Vector2 Delta() {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Input.GetTouch(0).deltaPosition;
#else

        return instance.delta;
#endif
    }
}
