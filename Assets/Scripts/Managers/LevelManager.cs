using UnityEngine;

public class LevelManager : MonoBehaviour {
    [SerializeField] private float survivalTimeInSeconds;
    [SerializeField] private FloatReference timer;


    private void Start() {
        timer.value = survivalTimeInSeconds;
    }

    private void Update() {
        timer.value -= Time.deltaTime;
        if (timer.value <= 0) {
            //TODO: End game
        }
    }
}
