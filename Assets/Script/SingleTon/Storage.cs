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
