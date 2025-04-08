using System.Collections;
using TMPro;
using UnityEngine;

public class InfoUIController : MonoBehaviour
{
    [SerializeField] private TextMeshPro infoText; // Reference to the UI Text component.
    public float displayTime = 3f; // Time to display the text before it disappears.

    private void Awake()
    {
        if (infoText == null)
        {
            infoText = GetComponent<TextMeshPro>(); // Auto-find TextMeshPro if not assigned
        }
    }
    public void ShowInfo(string message)
    {
        infoText.text = message;
        infoText.gameObject.SetActive(true);

        StartCoroutine(HideInfoAfterTime());

    }

    private IEnumerator HideInfoAfterTime()
    {
        yield return new WaitForSeconds(displayTime);  // Wait for the displayTime
        infoText.gameObject.SetActive(false);  // Hide the text
    }
}