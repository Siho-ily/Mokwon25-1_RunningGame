using UnityEngine;


public class Obstacle : MonoBehaviour
{
    [Header("Component")]
    private Player player;                  // 플레이어 스크립트
    private GameObject playerObj;           // 플레이어 오브젝트
    private BoxCollider playerCollider;     // 플레이어 콜라이더


	void Start()
    {
        // 플레이어 객체 연결
        playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<Player>();
            playerCollider = player.playerCollider;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        // 장애물과 충돌 시 게임 오버
        if (collider == playerCollider)
        {
            ScoreManager.Instance.StopScoring(); // 점수 정지
            //ScoreManager.Instance.SaveScore();   // 점수 저장 (선택)
            GameManager.Instance.gameSpeed = 0; //게임 speed = 0
    
            UIManager ui = FindAnyObjectByType<UIManager>();
            ui.ShowGameOver();

            Storage.Instance.PrintAllScores();
            
            Debug.Log("게임 오버!");
            

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 씬 재시작
        }
    }

    // 필요한 경우 추가 설정
}