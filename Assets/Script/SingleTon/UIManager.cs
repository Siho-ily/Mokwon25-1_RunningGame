using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public TextMeshProUGUI FinalScore;

    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
        Storage storage = new Storage();
        storage.AddScore(ScoreManager.Instance.IntCurrentScore); // ✅ 인스턴스 방식으로 호출

        FinalScore.text = "FinalScore: " + ScoreManager.Instance.IntCurrentScore;
    }

    public void OnRetryButtonClicked()
    {
        GameOverPanel.SetActive(false);
        GameManager.Instance.gameSpeed = 1f; // 혹시 게임 정지돼 있었다면 복구
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 씬 재시작
    }
}
