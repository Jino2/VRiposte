using System;
using Models;
using UnityEngine;
using Utils;

public class GameManager : MonoBehaviour
{
    public float initTime = 30; 
    
    private static GameManager instance;
    private GameTimer timer;
    private bool hit = false;
    private int playerPoints = 0;
    private int enemyPoints = 0;
    
    public static GameManager GetInstance()
    {
        if (instance != null) return instance;

        instance = new GameManager();
        return instance;
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else if(instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        this.timer = new GameTimer(startTime: initTime);
        this.StartGame(); // TODO : 테스트용 코드 이후 StartGame을 위한 위치로 이동...
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
        hit = false;
        timer.Start();
    }

    public void FinishGame()
    {
        timer.Pause();
        //TODO: 점수 계산 및 결과 출력
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
        // TODO: 맞았을때의 로직 우선 테스트를 위해 타이머만 멈춤
        timer.Pause();
    }
}
