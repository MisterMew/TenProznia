using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[ExecuteInEditMode]
public class ImageFillGradient : MonoBehaviour {
    [SerializeField] private Gradient gradient = null;
    [SerializeField] private Image image = null;

    /// <summary>
    /// Get image component upon awake
    /// </summary>
    private void Awake() {
        image = GetComponent<Image>();
    }

    /// <summary>
    /// update the images fill gradient by amount
    /// </summary>
    private void Update() {
        image.color = gradient.Evaluate(image.fillAmount);
    }
}