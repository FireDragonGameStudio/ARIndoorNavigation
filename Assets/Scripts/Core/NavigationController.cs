using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour {

    public Vector3 TargetPosition { get; set; } = Vector3.zero;

    public NavMeshPath CalculatedPath { get; private set; }
    public GameObject DestinationPin;


    private void Start() {
        CalculatedPath = new NavMeshPath();
    }

    private void Update() {
        if (TargetPosition != Vector3.zero) {
            NavMesh.CalculatePath(transform.position, TargetPosition, NavMesh.AllAreas, CalculatedPath);
            DestinationPin.SetActive(true);
            DestinationPin.transform.position = TargetPosition;
            DestinationPin.transform.position = new Vector3(DestinationPin.transform.position.x, DestinationPin.transform.position.y + 0.8f, DestinationPin.transform.position.z);
            DestinationPin.transform.Rotate(Vector3.up * (5f * Time.deltaTime));
        }
    }
}
