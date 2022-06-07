using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuController : MonoBehaviour
{
    [SerializeField] 
    private UIOptionsController ui_OptionsController;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
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
