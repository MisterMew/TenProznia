using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour {
    /// Variables
    public AudioMixer audioMixer = default;
    public Animator crossfade = default;
    public float transitionTime = 1f;
    private int sceneToLoad = 0;

      /// <summary>
     /// Reset the music after a fade
    /// </summary>
    public void Awake() {
        StartCoroutine(AudioMixerSliders.StartFade(audioMixer, "volMaster", 1F, 1f));
    }

      /// <summary>
     /// Start the process to fade into the next scene
    /// </summary>
    public void FadeToScene(int sceneIndex) {
        sceneToLoad = sceneIndex;
        crossfade.SetTrigger("FadeOut");
        StartCoroutine(AudioMixerSliders.StartFade(audioMixer, "volMaster", 3F, 0.0001f));
    }

      /// <summary>
     /// Load scene once fade is complete
    /// </summary>
    public void OnFadeComplete() {
        SceneManager.LoadScene(sceneToLoad);
    }
}
