using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var scores = Storage.Instance.LoadScoreList();
        string rankText = "";
        for (int i = 0; i < scores.Count; i++)
        {
            rankText += $"{i + 1}:\t {scores[i]}\n";
        }

        textMeshPro.text = rankText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
