using UnityEngine;

public class CactusObstacle : MonoBehaviour
{
    public float moveSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // 화면 밖으로 나가면 제거
        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
}
