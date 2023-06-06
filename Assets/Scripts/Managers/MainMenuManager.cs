using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    private void Start() {
        GameManager.s_instance.changeGameSate(GameState.MainMenu);
    }

    public void playGame() {
        GameManager.s_instance.changeGameSate(GameState.Playing);
        SceneManager.LoadScene("SampleScene");
    }
}