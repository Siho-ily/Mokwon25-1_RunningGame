using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            if (scoreText == null)
            {
                Debug.LogError("❌ ScoreText 오브젝트를 찾을 수 없습니다.");
            }
        }
    }

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
