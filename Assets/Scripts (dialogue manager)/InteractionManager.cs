using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public TextMeshPro interactionText;  // Reference to the Text UI component

    // Show interaction text and start the timer to hide it
    public void ShowInteractionText(string message)
    {
        if (interactionText != null)
        {
            interactionText.text = message;
            interactionText.gameObject.SetActive(true);  // Show the new text
            StartCoroutine(HideTextAfterDelay());
        }
    }

    // Coroutine to hide the interaction text after a delay
    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(3f);  // Adjust the delay as needed
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);  // Hide the text
        }
    }
}
