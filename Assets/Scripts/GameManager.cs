using System;
using Models;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Utils;

public class GameManager : MonoBehaviour
{
    public float initTime = 30;
    public int playerPoints { get; private set; } = 0;
    public int enemyPoints { get; private set; } = 0;
    public bool isGamePaused { get; private set; } = true;
    public GameResult result { get; private set; } = GameResult.None;
    public UnityEvent startCountDownEvent = null;

    private static GameManager instance;
    private GameTimer timer;

    public static GameManager GetInstance()
    {
        if (instance != null) return instance;

        instance = new GameManager();
        return instance;
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        this.timer = new GameTimer(startTime: initTime);
        startCountDownEvent?.Invoke();
    }

    // Update is called once per frame
    private void Update()
    {
        timer.UpdateDeltaTime(Time.deltaTime);
        if (timer.isFinished) FinishGame();
    }

    public float GetRemainTime()
    {
        return timer.remainTime;
    }

    public void StartGame()
    {
        isGamePaused = false;
        timer.Start();
    }

    public void FinishGame()
    {
        timer.Pause();
        this.result = GetResultByPoint();
    }

    
    // TODO : 시간 다됐을때 결과 안나도 끝남.. 처리 필요한데 일단 15분이라는 시간안에는 게임이 끝날것같아서 미룸
    private GameResult GetResultByPoint()
    {
        return playerPoints > enemyPoints ? GameResult.PlayerWin : GameResult.PlayerLose;
    }


    /// <summary>
    /// 캐릭터가 맞은걸 알려줍니다
    /// </summary>
    /// <param name="targetType">맞은 대상</param>
    /// <example>
    /// Hit(CharacterType.Enemy) => player가 enemy를 친경우
    /// </example>
    public void Hit(CharacterType targetType)
    {
        PauseGame();
        switch (targetType)
        {
            case CharacterType.Enemy:
                playerPoints++;
                break;

            case CharacterType.Player:
                enemyPoints++;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(targetType), targetType, null);
        }
        if(playerPoints < 15 && enemyPoints < 15 ) RestartGame();
        else FinishGame();
    }


    private void PauseGame()
    {
        isGamePaused = true;
        timer.Pause();
    }

    private void RestartGame()
    {
        startCountDownEvent?.Invoke();
    }
}