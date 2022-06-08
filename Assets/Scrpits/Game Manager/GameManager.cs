using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    bool gameStarted = false;

    enum PlayerWon
    {
        Left,
        Right
    }; private PlayerWon playerWon;
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
            if (timerStartGame >= startMarginTime)
            {
                ball.SetVelocity(lastPointed);
                gameStarted = true;
                timerStartGame = 0;
            }
        }
    }
}
