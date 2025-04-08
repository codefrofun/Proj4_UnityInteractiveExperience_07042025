using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{
    private Queue<string> Dialogue;

    public GameObject dialogueBox;
    public TextMeshPro dialogueUI;

    public bool activeDialogue = false;

    public PlayerMovement playerMovement; 
    public PlayerInteraction playerInteraction;

    public Button nextButton; // Reference to the Next button

    void Start()
    {
        Dialogue = new Queue<string>();

        dialogueBox.SetActive(false);

        // If the nextButton is assigned, add a listener to the button
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(NextInQueue);
        }
    }

    public void DialogueUI(string[] sentances)
    {
        activeDialogue = true;
        Dialogue.Clear();
        dialogueBox.SetActive(true);

        foreach (string sentance in sentances)
        {
            Dialogue.Enqueue(sentance);
        }

        NextInQueue();
    }
    public void NextInQueue()
    {
        if (Dialogue.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            dialogueUI.text = Dialogue.Dequeue();
        }
    }

    void EndDialogue()
    {
        Dialogue.Clear();
        dialogueBox.SetActive(false);
        dialogueUI.text = string.Empty;
        activeDialogue = false;
    }

    private void Update()
    {
        if (playerMovement != null) // Check if playerMovement is assigned
        {
            playerMovement.PlayerMove = !activeDialogue;
        }

        if (playerInteraction != null) // Check if playerInteraction is assigned
        {
            playerInteraction.currentInteractable = activeDialogue ? null : playerInteraction.currentInteractable;
        }
    }
}