using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private string spawnPointName; 

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /* //Method to load a new scene and preserve the player across scenes
    public void LoadScene(string sceneName)
    {
        // Ensure the player object persists across scene changes
        GameObject player = GameManager.Instance.player.gameObject;
        DontDestroyOnLoad(player);

        // Load the new scene
        SceneManager.LoadScene(sceneName);
    } */

    public void LoadSceneToSpawnPosition(string sceneName, string spawnPoint)
    {
        spawnPointName = spawnPoint;

        SceneManager.LoadScene(sceneName);
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameManager.Instance.player.gameObject;

            SetPlayerToSpawn(spawnPointName);
        Debug.Log("Scene loaded: " + scene.name);
    }

    //set spawn by name
    private void SetPlayerToSpawn(string spawnPointName)
    {
        GameObject spawnPoint = GameObject.Find(spawnPointName);

        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        if (spawnPoint != null)
        {
            Transform spawnPointTransform = spawnPoint.transform;
            Game_Manager.Instance.player.transform.position = spawnPointTransform.position;
        }
        else
        {
            // Debug log
        }
    }
}
