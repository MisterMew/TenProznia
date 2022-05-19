using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    /// Variables
    bool gameEnded = false;
    public float restartDelay = 1F;

     /// GAME: END
    /* Ends the game */
      /// <summary>
     /// End the game by Invoking a restart
    /// </summary>
    public void EndGame() {
        if (gameEnded == false) {
            gameEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

      /// <summary>
     /// Reload the current scene
    /// </summary>
    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
