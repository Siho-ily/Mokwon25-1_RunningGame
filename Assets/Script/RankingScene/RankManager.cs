using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    public Transform rankListParent;
    public GameObject rankItemPrefab;

    void Start()
    {
        SaveScore(PlayerPrefs.GetInt("LatestScore"));
        ShowRank();
    }

    void SaveScore(int score)
    {
        List<int> scores = LoadScores();
        scores.Add(score);
        scores = scores.OrderByDescending(s => s).Take(10).ToList();

        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt("Score_" + i, scores[i]);
        }

        PlayerPrefs.Save();
    }

    List<int> LoadScores()
    {
        List<int> scores = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey("Score_" + i))
            {
                scores.Add(PlayerPrefs.GetInt("Score_" + i));
            }
        }

        return scores;
    }

    void ShowRank()
    {
        foreach (Transform child in rankListParent)
        {
            Destroy(child.gameObject);
        }

        List<int> scores = LoadScores();

        for (int i = 0; i < scores.Count; i++)
        {
            GameObject item = Instantiate(rankItemPrefab, rankListParent);
            item.GetComponent<TMP_Text>().text = $"{i + 1}. {scores[i]}Á¡";
        }
    }
}
