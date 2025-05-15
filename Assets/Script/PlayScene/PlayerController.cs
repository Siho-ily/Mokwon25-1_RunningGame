using UnityEngine;
using UnityEngine.SceneManagement; // 씬 재시작용

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 장애물과 충돌 시 게임 오버
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("게임 오버!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 씬 재시작
        }
    }
}
