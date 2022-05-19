using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class AudioMixerSliders : MonoBehaviour {
    /// Variables
    private static AudioMixerSliders musicTransitionInstance;

    /// Slider Variables
    [SerializeField] private string volumeParameter = "volMaster";
    [SerializeField] private AudioMixer audioMixer = default;
    [SerializeField] private Slider slider = default;
    [SerializeField] private float volumeMultiplier = 20F;

       /// AWAKE
      /// <summary>
     /// Upon Awake
    /// </summary>
    private void Awake() {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

       /// START
      /// <summary>
     /// Execute PlayerPrefs upon start
    /// </summary>
    private void Start() {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
    }

    /// <summary>
    /// On disable, save the player prefs
    /// </summary>
    private void OnDisable() {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }

    /// <summary>
    /// Calculate and set the mixer value when the slider is changed
    /// </summary>
    private void HandleSliderValueChanged(float sliderValue) {
        audioMixer.SetFloat(volumeParameter, Mathf.Log10(sliderValue) * volumeMultiplier);
    }

    /// START FADE
    /* Fade out the audio mixer */
    /// <summary>
    /// Fade the master mixer when tansitioning scenes
    /// </summary>
    public static IEnumerator StartFade(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume) {
        float currentTime = 0;
        float currentVol;
        audioMixer.GetFloat(exposedParam, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVolume, 0.0001F, 1);

        while (currentTime < duration) {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
            yield return null;
        }
        yield break;
    }
}
