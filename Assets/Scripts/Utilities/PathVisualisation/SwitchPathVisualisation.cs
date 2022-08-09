using UnityEngine;

public class SwitchPathVisualisation : MonoBehaviour {

    [SerializeField]
    private PathLineVisualisation pathLineVis;
    [SerializeField]
    private PathArrowVisualisation arrowLineVis;

    private int visualisationCounter = 0;
    private GameObject activeVisualisation;

    private void Start() {
        activeVisualisation = pathLineVis.gameObject;
    }

    public void NextLineVisualisation() {
        visualisationCounter++;

        DisableAllPathVisuals();
        EnablePathVisualsByIndex(visualisationCounter);
    }

    private void DisableAllPathVisuals() {
        pathLineVis.gameObject.SetActive(false);
        arrowLineVis.gameObject.SetActive(false);
    }

    private void EnablePathVisualsByIndex(int visIndex) {
        switch (visIndex) {
            case 1:
                activeVisualisation = arrowLineVis.gameObject;
                break;
            default:
                activeVisualisation = pathLineVis.gameObject;
                visualisationCounter = 0;
                break;
        }

        activeVisualisation.SetActive(true);
    }

    public void ToggleVisualVisibility() {
        activeVisualisation.SetActive(!activeVisualisation.activeSelf);
    }
}
