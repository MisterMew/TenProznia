using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {
    /// Variables
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverlay;
    public GameObject buttonInputs;

    /// UPDATE
    /* Check update for key press to pause */
    /// <summary>
    /// Check update for key press to pause game
    /// </summary>
    private void Update() {
        if (ValidatePauseInput()) {
            if (gameIsPaused) { //If the game is paused
                ResumeGame();  //Resume the game.
            } else {
                PauseGame(); //Otherwise the game is unpaused, so pause it
            }
        }
    }

    /// GAME: Resume
    /* Resume the game if paused */
    /// <summary>
    /// Resume the game
    /// </summary>
    public void ResumeGame() {
        pauseMenuUI.SetActive(false);
        gameOverlay.SetActive(true);
        buttonInputs.SetActive(true);
        Time.timeScale = 1F;
        gameIsPaused = false;
    }

    /// GAME: Pause
    /* Pause the game */
    /// <summary>
    /// Pause the game
    /// </summary>
    public void PauseGame() {
        pauseMenuUI.SetActive(true);
        gameOverlay.SetActive(false);
        buttonInputs.SetActive(false);
        Time.timeScale = 0F;
        gameIsPaused = true;
    }

    /// RETURN MAIN
    /* Returns use to the main menu */
    /// <summary>
    /// Return to main menu
    /// </summary>
    public void ReturnToMenu() {
        //SceneTransitioner st = new SceneTransitioner();
        //st.CrossfadeScene("MainMenu");
        SceneManager.LoadScene("MainMenu");
        ResumeGame();
    }

    /// GAME: RESTART
    /* Restarts the current game */
    /// <summary>
    /// Restart the game
    /// </summary>
    public void RestartGame() {
        SceneManager.LoadScene("EndlessVoid");
        ResumeGame();
    }

    /// VALIDATE INPUT
    /* Validate if an input to trigger pausing has occured */
    /// <summary>
    /// Validate if an input to trigger pausing has occured
    /// </summary>
    public bool ValidatePauseInput() {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {
            return true;
        }
        return false;
    }

    /// QUIT
    /* Quit the Game */
    /// <summary>
    /// Quit the game
    /// </summary>
    public void QuitGame() {
        Application.Quit();
    }
}
