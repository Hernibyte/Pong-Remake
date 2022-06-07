using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptionsController : MonoBehaviour
{
    [SerializeField]
    private UIMenuController ui_MenuController;

    [SerializeField]
    private GameObject gameControls_Text;

    public void BackToMenu()
    {
        gameObject.SetActive(false);
        ui_MenuController.gameObject.SetActive(true);
    }

    public void ShowControls()
    {
        gameControls_Text.SetActive(true);
    }

    public void CloseControls()
    {
        gameControls_Text.SetActive(false);
    }
}
