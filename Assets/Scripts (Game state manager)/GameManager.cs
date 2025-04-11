using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance { get; private set; }


    public GameStateManager gameStateManager;
    public UIManager uiManager;
    public LevelManager levelManager;
    public PlayerMovement player; // To insantiate player


    private void Awake()
    {
        if (GameManager.Instance == null)
        {

            Instance = this; // Set the singleton instance
            DontDestroyOnLoad(gameObject); // Prevent destruction on scene load
            Debug.Log("Game manager is active");
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate if one already exists
            Debug.Log("Game manager is destroyed");
        }
    }
 
}