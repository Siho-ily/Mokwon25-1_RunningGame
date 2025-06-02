using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public float CurrentScore { get; private set; } = 0;
    public int IntCurrentScore { get; private set; } = 0;
    public int HighScore => PlayerPrefs.GetInt("HighScore", 0);

    private bool isRunning = true;

    void Start()
    {
        ScoreManager.Instance.ResetScore();
    }


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (!isRunning) return;

        // 1초에 10점씩 증가
        CurrentScore += Time.deltaTime * 4f;
        // 게임 속도 증가
        GameManager.Instance.SetGameSpeed(CurrentScore / 300f + 1f);
        IntCurrentScore = Mathf.FloorToInt(CurrentScore); //float int로 변환
    }

    public void StopScoring()
    {
        isRunning = false;
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        isRunning = true;
    }

    // public void SaveScore()
    // {
    //     if (CurrentScore > HighScore)
    //     {
    //         PlayerPrefs.SetInt("HighScore", CurrentScore);
    //     }

    //     PlayerPrefs.SetInt("LastScore", CurrentScore);
    // }
}
