using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public TextMeshProUGUI FinalScore;

    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
        
        FinalScore.text = "FinalScore: " + ScoreManager.Instance.IntCurrentScore;
    }
}
