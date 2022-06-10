using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace CustomEvents
{
    public class SFloat_e : UnityEvent<float> { }
    public class Single_e : UnityEvent { }
    public class GM_e : UnityEvent<GameManager> { }
}

public class GameManager : MonoBehaviour
{
    public CustomEvents.GM_e gameEnded_e = new CustomEvents.GM_e();
    public CustomEvents.SFloat_e gameTimerCount_e = new CustomEvents.SFloat_e();
    public CustomEvents.Single_e gameTimerCountEnd_e = new CustomEvents.Single_e();

    [SerializeField] private float startMarginTime;
    public int maxGamePoints = 6;

    public int leftPlayerPoints { get; private set; }
    public int rightPlayerPoints { get; private set; }

    private Ball ball;
    [SerializeField]
    private Player leftPlayer;
    [SerializeField]
    private Player rightPlayer;

    float timerStartGame = 0;
    [HideInInspector]
    public bool gameStarted = false;

    public enum PlayerWon
    {
        Left,
        Right
    }; public PlayerWon playerWon;
    bool gameEnded = false;

    MyBall.StartDirection lastPointed;

    private void Awake()
    {
        ball = FindObjectOfType<Ball>();
    }

    private void Start()
    {
        ball.triggerWithGoal.AddListener(Pointed);
    }

    private void Update()
    {
        StartGameMargin();
        if (gameEnded) gameEnded_e.Invoke(this);
    }

    private void Pointed(MyGoals.ETypeGoal type)
    {
        if (type == MyGoals.ETypeGoal.LeftGoal)
        {
            rightPlayerPoints++;
            lastPointed = MyBall.StartDirection.Left;
            if (rightPlayerPoints >= maxGamePoints)
            {
                gameEnded = true;
                playerWon = PlayerWon.Right;
            }
        }
        else
        {
            leftPlayerPoints++;
            lastPointed = MyBall.StartDirection.Right;
            if (leftPlayerPoints >= maxGamePoints)
            {
                gameEnded = true;
                playerWon = PlayerWon.Left;
            }
        }
        ball.Reset();
        leftPlayer.Reset();
        gameStarted = false;
    }

    public void StartGameMargin()
    {
        if (!gameStarted && !gameEnded)
        {
            timerStartGame += Time.deltaTime;
            gameTimerCount_e.Invoke(timerStartGame);
            if (timerStartGame >= startMarginTime)
            {
                gameTimerCountEnd_e.Invoke();
                ball.SetVelocity(lastPointed);
                gameStarted = true;
                timerStartGame = 0;
            }
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
