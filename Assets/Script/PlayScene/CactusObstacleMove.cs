using UnityEngine;

public class CactusObstacleMove : MonoBehaviour
{
    private CactusObstacle cactusObstacle;

    void Awake()
    {
        cactusObstacle = GetComponent<CactusObstacle>();
    }

    void Update()
    {
        transform.position += Vector3.left * cactusObstacle.moveSpeed * Time.deltaTime;
    }
}
