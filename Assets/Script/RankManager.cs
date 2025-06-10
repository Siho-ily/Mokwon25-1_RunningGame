using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
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
}
