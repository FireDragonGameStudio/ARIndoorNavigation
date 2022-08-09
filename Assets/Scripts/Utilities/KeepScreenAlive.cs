using UnityEngine;

public class KeepScreenAlive : MonoBehaviour {

    private void Start() {
        // disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
