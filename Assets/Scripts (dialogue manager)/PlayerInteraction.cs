using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 2f;  // Range in which the player can interact with an object
    public InteractableObject currentInteractable { get; set; } // made public

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();  // Call the Interact method on the object
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player is in range of an interactable object
        if (other.CompareTag("Interactable"))
        {
            currentInteractable = other.GetComponent<InteractableObject>();
        }
    }

    // Detect when the player exits the collider area
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            currentInteractable = null;
        }
    }
}
