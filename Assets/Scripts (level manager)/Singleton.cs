using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2025

public class Singleton : MonoBehaviour
{
    // this script sets itself, and all children as a Single Instance
    // When a new scene is loaded the object with this script (and all it's children) will be carried into the new scene.
    // allows you to carry main functionality objects between scenes

    static Singleton Instance;

    void Start()
    {
        if (Instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
}