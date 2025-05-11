using UnityEngine;

[RequireComponent(typeof(Platform))]
public class PlatformMove : MonoBehaviour
{
    private Platform platform;

    void Awake()
    {
        platform = GetComponent<Platform>();
    }

    void Update()
    {
        transform.position += Vector3.left * platform.moveSpeed * Time.deltaTime;
    }
}