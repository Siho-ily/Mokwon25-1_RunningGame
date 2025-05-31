using UnityEngine;

public class Storage : MonoBehaviour
{
    // 싱글톤 선언부
    public static Storage Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 경우 중복 생성 방지
        }
    }

    // 테스트용 print
    public void PrintTest()
    {
        Debug.Log("Storage Instance is working!");
    }

    // 최대 저장 개수
    private const int MaxScoreCount = 10;
    private const string HighScoreKey = "highscore";
    private const string ScoreListKey = "scorelist";

    // 점수 저장
    public void AddScore(int score)
    {
        // 기존 점수 리스트 불러오기
        var scores = LoadScoreList();
        scores.Add(score);
        // 내림차순 정렬 후 최대 10개만 유지
        scores.Sort((a, b) => b.CompareTo(a));
        if (scores.Count > MaxScoreCount)
            scores = scores.GetRange(0, MaxScoreCount);

        // 최고점 저장
        int highscore = scores[0];
        PlayerPrefs.SetInt(HighScoreKey, highscore);

        // 점수 리스트 저장 (콤마로 구분된 문자열)
        string scoreListStr = string.Join(",", scores);
        PlayerPrefs.SetString(ScoreListKey, scoreListStr);
        PlayerPrefs.Save();
    }

    // 점수 리스트 불러오기
    public System.Collections.Generic.List<int> LoadScoreList()
    {
        var list = new System.Collections.Generic.List<int>();
        string scoreListStr = PlayerPrefs.GetString(ScoreListKey, "");
        if (!string.IsNullOrEmpty(scoreListStr))
        {
            var items = scoreListStr.Split(',');
            foreach (var item in items)
            {
                if (int.TryParse(item, out int val))
                    list.Add(val);
            }
        }
        return list;
    }
    
    // 저장된 점수 리스트를 확인하는 메서드
    public void PrintAllScores()
    {
        var scores = LoadScoreList();
        Debug.Log("저장된 점수 목록:");
        for (int i = 0; i < scores.Count; i++)
        {
            Debug.Log($"{i + 1}위: {scores[i]}");
        }
    }

    // 최고점 불러오기
    public int LoadHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }
    

    // 데이터 저장
    public void SaveData(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save(); // 저장
    }

    // 데이터 불러오기
    public string LoadData(string key)
    {
        return PlayerPrefs.GetString(key, ""); // 기본값은 빈 문자열
    }
}
