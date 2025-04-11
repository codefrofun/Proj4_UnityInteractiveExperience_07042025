using UnityEngine;

public class TriggerSceneChange_Prefab : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private string spawnPointName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Trigger entered! Scene Name: " + sceneName); // Log the scene name
            if (!string.IsNullOrEmpty(sceneName) && !string.IsNullOrEmpty(spawnPointName))
            {
                Debug.Log("Player entered trigger. Changing scene to: " + sceneName + " and spawn point: " + spawnPointName);

                if (GameManager.Instance != null)
                {
                    GameManager.Instance.levelManager.LoadSceneToSpawnPosition(sceneName, spawnPointName);
                }
                else
                {
                    Debug.LogError("Game Manager instance is not found!");
                } 
            }
        }
    }
}
