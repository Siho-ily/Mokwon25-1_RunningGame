using UnityEngine;
using UnityEngine.SceneManagement;


public class CactusObstacle : MonoBehaviour
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
            Debug.Log("게임 오버!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 씬 재시작
        }
    }

    // 필요한 경우 추가 설정
}
