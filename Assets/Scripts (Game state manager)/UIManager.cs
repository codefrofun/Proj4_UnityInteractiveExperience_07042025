using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameManager gameManager;
    public GameStateManager gameStateManager;

    public GameObject mainMenuUI;
    public GameObject pauseUI;
    public GameObject optionUI;
    public GameObject settingsUI;

    public void EnableMainMenu()
    {
        DisableAll();
        mainMenuUI.SetActive(true);
    }

    public void EnableGameplay()
    {
        DisableAll();
        SceneManager.LoadScene("Level_1");
    }
    public void EnablePause()
    {
        DisableAll();
        pauseUI.SetActive(true);
    }

    public void EnableOptions()
    {
        DisableAll();
        optionUI.SetActive(true);
    }

    public void EnableSettings()
    {
        DisableAll();
        settingsUI.SetActive(true);
    }

    public void ReturnButton()
    {
        gameManager.gameStateManager.ChangeState(gameManager.gameStateManager.previousState);
    }

    public void DisableAll()
    {
        mainMenuUI.SetActive(false);
        pauseUI.SetActive(false);
        optionUI.SetActive(false);
        settingsUI.SetActive(false);
    }
}
