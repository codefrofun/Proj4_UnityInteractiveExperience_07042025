using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IPlayerActions
{

    public GameInput gameInput;

    void Awake()
    {
        Debug.Log("InputManager is awake");

        if (FindObjectsOfType<InputManager>().Length > 1)
        {
            Destroy(gameObject); 
            return;
        }

        DontDestroyOnLoad(gameObject); // Don't destroy input 
                                       
        if (gameInput == null) // Initialize the gameInput only if it is not initialized yet
        {
            gameInput = new GameInput();  // Initialize gameInput if it's null
        }

        gameInput.Player.Enable();  // Enable the input actions
        gameInput.Player.SetCallbacks(this);  // Set up the callbacks
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        InputActions.CurrentMoveInput = context.ReadValue<Vector2>();
    }


    // Disable the input actions when the script is disabled
    void OnDisable()
    {
        // Check if gameInput is not null before disabling
        if (gameInput != null)
        {
            Debug.Log("InputManager is disabled");
            gameInput.Player.Disable();
        }
        else
        {
            Debug.LogWarning("gameInput is null in OnDisable");
        }
    }
}

public static class InputActions
{
    public static Vector2 CurrentMoveInput { get; set; }
}