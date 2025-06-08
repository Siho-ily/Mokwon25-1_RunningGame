using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlatformOneWay : MonoBehaviour
{
    [SerializeField] private float yMargin = 0.05f;

    private Collider platformCollider;
    private Collider playerCollider;
    private Rigidbody playerRb;

    void Start()
    {
        platformCollider = GetComponent<Collider>();

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            Player player = playerObj.GetComponent<Player>();
            playerCollider = player.playerCollider;
            playerRb = player.GetComponent<Rigidbody>();
        }
    }

    void FixedUpdate()
    {
        if (platformCollider == null || playerCollider == null || playerRb == null) return;

        Bounds playerBounds = playerCollider.bounds;
        Bounds platformBounds = platformCollider.bounds;

        float playerBottom = playerBounds.min.y;
        float platformTop = platformBounds.max.y;

        float vy = playerRb.linearVelocity.y;

        // 플레이어 바닥에서 Raycast
        Vector3 rayOrigin = new Vector3(
            playerBounds.center.x,
            playerBounds.min.y+0.3f,
            playerBounds.center.z
        );

        // 10번 레이어(Platform) 감지
        bool isPlatformBelow = Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, 0.8f, LayerMask.GetMask("Platform"));

        
        if (vy > 0f || playerBottom < platformTop + yMargin && !isPlatformBelow)
        {
            Physics.IgnoreCollision(playerCollider, platformCollider, true);
        }
        else
        {
            // 낙하 중이고 플랫폼보다 충분히 위 → 충돌 허용
            Physics.IgnoreCollision(playerCollider, platformCollider, false);
        }
    }
}
