using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        if (ScoreManager.Instance == null)
        {
            Debug.Log("ScoreManager 인스턴스가 없습니다!");
            return;
        }


        scoreText.text = "Score: " + ScoreManager.Instance.IntCurrentScore.ToString();

    }
}
