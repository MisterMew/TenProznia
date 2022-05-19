using UnityEngine;
using Cinemachine;

public class MainMenuManager : MonoBehaviour {
    /// Animation Variables
    public Animator options;
    
    /// Cinematic Variables
    private bool cmVirtualCam01 = true;
    private Animator cmAnimator = default;
    [SerializeField] private CinemachineVirtualCamera vCam01 = default;  //Menu camera
    [SerializeField] private CinemachineVirtualCamera vCam02 = default; //Credits camera

    /// AWAKE
    /* Get Components */
    /// <summary>
    /// Get alll required components upon Awake
    /// </summary>
    private void Awake() {
        Screen.orientation = ScreenOrientation.LandscapeLeft; //Set the screen orientation
        cmAnimator = GetComponent<Animator>();               //Get cinemachine component
        options = GetComponent<Animator>();                 //Get UI animator component
    }

    /// <summary>
    /// Trigger the options menu
    /// </summary>
    public void OptionsMenu() {
        options.SetTrigger("OpenOptions");
    }

    /// UI: Quit
    /* Upon button click, quit the game */
    /// <summary>
    /// Quit the game
    /// </summary>
    public void QuitGame() {
        Application.Quit();
    }

    /// UI: Credits
    /* Upon button click, view credits */
    /// <summary>
    /// View the credits menu
    /// </summary>
    public void ViewCredits() {
        SwitchCMPriority();
    }

    /// <summary>
    /// return to the main menu (from credits)
    /// </summary>
    public void ReturnMain() {
        SwitchCMPriority();
    }

    /// CM: Switch Priority
    /* Switch the camera priority */
    /// <summary>
    /// Switch the cinemachine camera view via priotity
    /// </summary>
    private void SwitchCMPriority() {
        if (cmVirtualCam01) {
            vCam01.Priority = 0;  //Switch priority from MAIN camera
            vCam02.Priority = 1; //to CREDITS Camera
        }
        else {
            vCam01.Priority = 1;
            vCam02.Priority = 0;
        }
        cmVirtualCam01 = !cmVirtualCam01;
    }
}
