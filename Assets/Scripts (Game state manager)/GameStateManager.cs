using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject inputManagerPrefab;

    public enum GameState
    { 
        // Different gamestates 
        MainMenu_State, Gameplay_State, Paused_State, Options_State, Settings_State
    }

    public GameState previousState; // Grab previous state after switching states

    public GameState currentState { get; private set; }

    [SerializeField] private string currentStateDebug;
    [SerializeField] private string lastStateDebug;

    private void Start()
    {
        // On start, show main menu
        ChangeState(GameState.MainMenu_State);
    }

    public void ChangeState(GameState newState)
    {
        lastStateDebug = currentState.ToString();
        previousState = currentState;

        currentState = newState;

        HandleStateChange(newState);

        currentStateDebug = currentState.ToString();
    }

    private void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentState == GameState.Gameplay_State)
            {
                Pause();
            }
            else if (currentState == GameState.Paused_State)
            {
                Resume();
            }
        } */

        if (Input.GetKeyDown(KeyCode.G) && currentState == GameState.MainMenu_State)
        {
            ChangeStateToGameplay();
        }

        if (Input.GetKeyDown(KeyCode.O) && currentState == GameState.MainMenu_State)
        {
            //ChangeStateToOption();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.gameStateManager.ChangeState(gameManager.gameStateManager.previousState);
        }
    }

    private void HandleStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu_State:
                Time.timeScale = 0f;
                gameManager.uiManager.EnableMainMenu();
                Debug.Log("Switched to Main Menu screen");
                break;

            case GameState.Gameplay_State:
                Time.timeScale = 1f;
                gameManager.uiManager.EnableGameplay();
                Debug.Log("Switched to Gameplay screen");
                break;

            case GameState.Paused_State:
                Time.timeScale = 0f;
                gameManager.uiManager.EnablePause();
                Debug.Log("Switched to Pause screen");
                break;

            case GameState.Options_State:
                Time.timeScale = 0f;
                gameManager.uiManager.EnableOptions();
                Debug.Log("Switched to options screen");
                break;

            case GameState.Settings_State:
                Time.timeScale = 0f;
                gameManager.uiManager.EnableSettings();
                Debug.Log("Switched to Settings screen");
                break;

        }
    }

    public void ChangeStateToMainMenu()
    {
        ChangeState(GameState.MainMenu_State);
        gameManager.uiManager.EnableMainMenu();
    }

    public void Resume()
    {
        //ChangeState(GameState.Gameplay_State); // broken
        ReturnButton();
    }

    public void Pause()
    {
        ChangeState(GameState.Paused_State);
    }

    public void ChangeStateToGameplay()
    {
       /*  if (FindObjectOfType<InputManager>() == null)
        {
            GameObject inputManager = Instantiate(inputManagerPrefab);  // Make sure it's not destroyed
            DontDestroyOnLoad(inputManager);
        } */

        ChangeState(GameState.Gameplay_State);
    }

    public void ChangeStateToOption()
    {
        ChangeState(GameState.Options_State);
    }

    public void ReturnButton()
    {
        ChangeState(previousState);
    }

    // Referenced quit game method from previous project, closes game to desktop.
    public void QuitGame()
    {
        Debug.Log("Quitting the game...");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}