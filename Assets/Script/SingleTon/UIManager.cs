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
        Storage.Instance.AddScore(ScoreManager.Instance.IntCurrentScore); // Storage 싱글톤으로 호출

        FinalScore.text = "FinalScore: " + ScoreManager.Instance.IntCurrentScore;
    }

    public void OnRetryButtonClicked()
    {
        GameOverPanel.SetActive(false);
        GameManager.Instance.gameSpeed = 1f; // 혹시 게임 정지돼 있었다면 복구
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 씬 재시작
    }

    public void OnMainMenuButtonClicked()
    {
        GameOverPanel.SetActive(false);
        GameManager.Instance.gameSpeed = 1f; // 혹시 게임 정지돼 있었다면 복구
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene("MainMenuScene"); // 메인 화면으로 이동
    }
}
