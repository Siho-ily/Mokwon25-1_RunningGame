using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Range(0f, 5f)]
    public float gameSpeed = 1f; // 1 = 기본 속도

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        ApplyGameSpeed(); // 시작 시 한번 적용
    }

    private void Update()
    {
        // 런타임 도중 슬라이더나 코드로 gameSpeed 바꾸면 자동 반영됨
        ApplyGameSpeed();
    }

    public void SetGameSpeed(float speed)
    {
        gameSpeed = Mathf.Clamp(speed, 0f, 5f);
        ApplyGameSpeed();
    }

    private void ApplyGameSpeed()
    {
        Time.timeScale = gameSpeed;
        Time.fixedDeltaTime = 0.02f / gameSpeed;
    }

}