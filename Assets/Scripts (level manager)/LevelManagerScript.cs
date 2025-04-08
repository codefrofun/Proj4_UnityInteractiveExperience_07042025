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

    public void LoadSceneToSpawnPosition(string sceneName, string spawnPoint)
    {
        spawnPointName = spawnPoint;

        SceneManager.LoadScene(sceneName);
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetPlayerToSpawn(spawnPointName);
        Debug.Log("Scene loaded: " + scene.name);
    }

    //set spawn by name
    private void SetPlayerToSpawn(string spawnPointName)
    {
        GameObject spawnPoint = GameObject.Find(spawnPointName);

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

//UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);