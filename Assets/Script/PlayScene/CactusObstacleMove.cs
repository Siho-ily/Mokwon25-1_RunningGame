using UnityEngine;

public class CactusObstacleMove : MonoBehaviour
{
    [Header("Variable")]
    public float moveSpeed = 4f;        // 장애물 움직임 속도

    void Update()
    {
        // 장애물 이동 구현
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
