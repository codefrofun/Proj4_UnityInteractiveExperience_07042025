using System.Collections;
using TMPro;
using UnityEngine;


public enum InteractableType
{
    Hint,
    Info,
    Pickup,
    Dialogue
}

public class InteractableObject : MonoBehaviour
{

    public InteractableType interactableType;
    public string interactionText;  // Text that appears when interacted with.
    public GameObject itemToPickup;

    public InfoUIController infoUIController;  // Reference to the InfoUIController script
    public TextMeshPro interactionText3D;  // Reference to the Text UI component

    public DialogueManagerScript dialogueManager;

    public string[] dialogueLines; // Lines can be written in the inspector.

    public void Interact()
    {

        switch (interactableType)
        {
            case InteractableType.Hint:
                // Handle hint interaction (show hint message)
                ShowInteractionText("Hint: " + interactionText);
                break;


            case InteractableType.Info:
                //Handle info interaction(show text above the player)
                ShowInteractionText("Info: " + interactionText);
                break;


            case InteractableType.Pickup:
                // Handle pickup interaction (Show message and hide item)
                if (infoUIController != null)
                {
                    infoUIController.ShowInfo("You got: " + interactionText); // Ensure UI handles the text visibility
                }

                if (itemToPickup != null)
                {
                    itemToPickup.SetActive(false); // Hide the item instead of destroying it
                }
                break;

            case InteractableType.Dialogue:
                // Handle dialogue interaction
                TriggerDialogue();
                break;
        }
    }

    private void ShowInteractionText(string message)
    {
        if (interactionText3D != null)
        {
            interactionText3D.gameObject.SetActive(false);  // Hide any previous text
            interactionText3D.text = message;
            interactionText3D.gameObject.SetActive(true);  // Show the new text

            StartCoroutine(HideTextAfterDelay());
        }
    }

    private void TriggerDialogue()
    {

        if (dialogueLines.Length > 0 && dialogueManager != null)
        {
            dialogueManager.DialogueUI(dialogueLines);  // Start the dialogue in the DialogueManager
        }
        else
        {
            Debug.LogWarning("Dialogue lines are empty or DialogueManager is not assigned!");
        }


        /* string[] dialogueLines = new string[]
        {
            "Good day, wanderer.",
            "This house does not have room for the both of us.",
            "Find all 3 keys and leave."
        };

        if (dialogueManager != null)
        {
            dialogueManager.DialogueUI(dialogueLines);  // Start the dialogue in the DialogueManager
        } */
    }

    private System.Collections.IEnumerator HideTextAfterDelay()
    {
        Debug.Log("Coroutine started: Hiding text in 3 seconds");
        yield return new WaitForSeconds(2.6f); // Adjust the duration if needed (between 2-3 is good!!)
        if (interactionText3D != null)
        {
            interactionText3D.gameObject.SetActive(false); // Hide the text
        }
    }
}
