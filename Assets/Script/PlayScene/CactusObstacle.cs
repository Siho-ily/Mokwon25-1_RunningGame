using UnityEngine;
using UnityEngine.SceneManagement;


public class CactusObstacle : MonoBehaviour
{
    [Header("Component")]
    private Player player;
    private GameObject playerObj;
    private BoxCollider playerCollider;


	void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<Player>();
            playerCollider = player.playerCollider;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider);
        Debug.Log(collider.ToString());
        // 장애물과 충돌 시 게임 오버
        if (collider == playerCollider)
        {
            Debug.Log("게임 오버!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 씬 재시작
        }
    }

    // 필요한 경우 추가 설정
}
