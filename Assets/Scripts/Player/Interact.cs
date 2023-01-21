using TMPro;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public CanvasGroup TextParent;
    public TMP_Text Text;
    public float DetectionRadius;
    public LayerMask InteractableLayer;

    private LTDescr tween;

    void Update()
    {
        var obj = Physics2D.OverlapCircle(transform.position, DetectionRadius, InteractableLayer);

        if (obj != null && obj.GetComponent<Interactable>() != null)
        {
            //! Enable Later
            // tween = LeanTween.alphaCanvas(TextParent, 1, Settings.GlobalSettings.AnimationSpeed);
            // Text.SetText($"Interact 'W'");

            if (Input.GetButtonDown("Interact"))
            {
                obj.GetComponent<Interactable>().OnInteract.Invoke();
                print($"Interacted with {obj.name}");
            }
        }
        // else
        //     tween = LeanTween.alphaCanvas(TextParent, 0, Settings.GlobalSettings.AnimationSpeed);
    }
}