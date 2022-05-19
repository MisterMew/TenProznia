using UnityEngine;

public class AudioManager : MonoBehaviour {
    /// Variables
    public AudioSource musicSource;

      /// <summary>
     /// Get the current music source upon awake
    /// </summary>
    private void Awake() {
        musicSource = GetComponent<AudioSource>();
    }
}