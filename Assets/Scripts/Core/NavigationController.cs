using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour {

    public Vector3 TargetPosition { get; set; } = Vector3.zero;

    [SerializeField]
    private LineRenderer line;
    [SerializeField]
    private Slider navigationYOffset;

    private NavMeshPath path;

    private void Start() {
        path = new NavMeshPath();

        // disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update() {
        if (line.gameObject.activeSelf && TargetPosition != Vector3.zero) {
            NavMesh.CalculatePath(transform.position, TargetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            Vector3[] calculatedPathAndOffset = AddLineOffset();
            line.SetPositions(calculatedPathAndOffset);
        }
    }

    private Vector3[] AddLineOffset() {
        if (navigationYOffset.value == 0) {
            return path.corners;
        }

        Vector3[] offsettedLine = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++) {
            offsettedLine[i] = path.corners[i] + new Vector3(0, navigationYOffset.value, 0);
        }
        return offsettedLine;
    }

    public void ToggleLineVisibility() {
        line.enabled = !line.enabled;
    }
}
