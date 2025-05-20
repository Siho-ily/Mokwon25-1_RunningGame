using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [Header("Variable")]
    public float moveSpeed = 4f;        // 플랫폼 움직임 속도

    void Update()
    {
        // 플랫폼 움직임 구현
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}