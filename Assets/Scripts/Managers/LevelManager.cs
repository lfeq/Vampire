using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    [SerializeField] private float survivalTimeInSeconds;
    [SerializeField] private FloatReference timer;
    [SerializeField] private GameEvent endGameEvent;


    private void Start() {
        timer.value = survivalTimeInSeconds;
    }

    private void Update() {
        timer.value -= Time.deltaTime;
        if (timer.value <= 0) {
            endGame();
        }
    }

    public void goToMenu() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        GameManager.s_instance.changeGameSate(GameState.MainMenu);
    }

    public void reloadGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    
    private void endGame() {
        endGameEvent.Raise();
        Time.timeScale = 0;
    }
}
