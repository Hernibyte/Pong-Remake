using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndGame : MonoBehaviour
{
    [SerializeField] private GameObject principalPanel;
    [SerializeField] private GameObject playerOneWon;
    [SerializeField] private GameObject playerTwoWon;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.gameEnded_e.AddListener(ActivateEndPanel);
    }

    private void ActivateEndPanel(GameManager gm)
    {
        principalPanel.SetActive(true);
        switch (gm.playerWon)
        {
            case GameManager.PlayerWon.Left:
                playerOneWon.SetActive(true);
                break;
            case GameManager.PlayerWon.Right:
                playerTwoWon.SetActive(true);
                break;
        }
    }
}
