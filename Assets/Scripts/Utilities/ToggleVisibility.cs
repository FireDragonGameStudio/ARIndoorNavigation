using UnityEngine;

public class ToggleVisibility : MonoBehaviour {

    [SerializeField]
    private GameObject toggleObject;

    public void Toggle() {
        toggleObject.SetActive(!toggleObject.activeSelf);
    }
}
