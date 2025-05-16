using UnityEngine;

[RequireComponent(typeof(Platform))]
public class PlatformMove : MonoBehaviour
{
    [Header("Variable")]
    public float moveSpeed = 2f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}