using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGamePoint : MonoBehaviour
{
    private GameManager gameManager;
    private TMPro.TextMeshProUGUI points;

    enum UsersPoints
    {
        LeftUser,
        RightUser
    }; 
    [SerializeField] 
    private UsersPoints usersPoints;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        points = GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        switch (usersPoints)
        {
            case UsersPoints.LeftUser:
                points.text = gameManager.leftPlayerPoints.ToString();
                break;
            case UsersPoints.RightUser:
                points.text = gameManager.rightPlayerPoints.ToString();
                break;
        }
    }
}
