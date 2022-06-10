using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimeCounter : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMPro.TextMeshProUGUI counter;

    private GameManager gameManager;
    float auxTimer = 4;

    const float counterTimer = 4;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameManager.gameTimerCount_e.AddListener(UpdateCounter);
        gameManager.gameTimerCountEnd_e.AddListener(HideCounter);
    }

    private void UpdateCounter(float time)
    {
        auxTimer -= time;
        panel.SetActive(true);
        if ((int)auxTimer == 0)
            counter.text = "GO";
        else
            counter.text = ((int)auxTimer).ToString();
        auxTimer = counterTimer;
    }

    private void HideCounter()
    {
        auxTimer = counterTimer;
        panel.SetActive(false);
    }
}
