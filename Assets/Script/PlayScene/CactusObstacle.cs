using UnityEngine;
using UnityEngine.SceneManagement;


public class CactusObstacle : MonoBehaviour
{
    public Player player;
    private bool isInitialized = false; // 초기화 여부
    [Header("CactusObstacle 기본 설정")]
    public float moveSpeed = 2f;

    void Update()
    {
        if (!isInitialized) return;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider);
        Debug.Log(collider.ToString());
        // 장애물과 충돌 시 게임 오버
        if (collider == player.playerCollider)
        {
            ScoreManager.Instance.StopScoring(); // 점수 정지
            //ScoreManager.Instance.SaveScore();   // 점수 저장 (선택)
            GameManager.Instance.gameSpeed = 0; //게임 speed = 0
    
            UIManager ui = FindObjectOfType<UIManager>();
            ui.ShowGameOver();

            Debug.Log("게임 오버!");
            

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 씬 재시작
        }
    }

}
