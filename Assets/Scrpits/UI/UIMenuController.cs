using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuController : MonoBehaviour
{
    [SerializeField]
    private UIOptionsController ui_OptionsController;

    [SerializeField]
    private GameObject InitialMenu;

    [SerializeField]
    private GameObject SelectModeMenu;

    public void PlayGame()
    {
        ShowSelectModeMenu();
    }

    public void PlaySinglePlayer()
    {
        GameConfig.Get.gameMode = GameMode.SinglePlayer;
        SceneManager.LoadScene("Game");
    }

    public void PlayMultiPlayer()
    {
        GameConfig.Get.gameMode = GameMode.MultiPlayer;
        SceneManager.LoadScene("Game");
    }

    public void ShowInitialMenu()
    {
        InitialMenu.SetActive(true);
        SelectModeMenu.SetActive(false);
    }

    public void ShowSelectModeMenu()
    {
        InitialMenu.SetActive(false);
        SelectModeMenu.SetActive(true);
    }

    public void OptionsGame() 
    {
        gameObject.SetActive(false);
        ui_OptionsController.gameObject.SetActive(true);
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
