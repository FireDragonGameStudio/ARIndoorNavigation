using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PathLineVisualisation : MonoBehaviour {

    [SerializeField]
    private NavigationController navigationController;
    [SerializeField]
    private LineRenderer line;
    [SerializeField]
    private Slider navigationYOffset;

    private NavMeshPath path;
    private Vector3[] calculatedPathAndOffset;

    private void Update() {
        path = navigationController.CalculatedPath;
        AddOffsetToPath();
        AddLineOffset();
        SetLineRendererPositions();
    }

    private void AddOffsetToPath() {
        calculatedPathAndOffset = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++) {
            calculatedPathAndOffset[i] = new Vector3(path.corners[i].x, transform.position.y, path.corners[i].z);
        }
    }

    private void AddLineOffset() {
        if (navigationYOffset.value != 0) {
            for (int i = 0; i < calculatedPathAndOffset.Length; i++) {
                calculatedPathAndOffset[i] += new Vector3(0, navigationYOffset.value, 0);
            }
        }
    }

    private void SetLineRendererPositions() {
        line.positionCount = calculatedPathAndOffset.Length;
        line.SetPositions(calculatedPathAndOffset);
    }
}
