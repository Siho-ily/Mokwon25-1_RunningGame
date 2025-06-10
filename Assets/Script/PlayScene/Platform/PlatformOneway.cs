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

        // 플레이어와 플랫폼의 Bounds 가져옴
        Bounds playerBounds = playerCollider.bounds;
        Bounds platformBounds = platformCollider.bounds;

        // 플레이어 바닥과 플랫폼 상단 위치 계산
        float playerBottom = playerBounds.min.y;
        float platformTop = platformBounds.max.y;

        // 플레이어의 Y축 속도 가져오기
        float vy = playerRb.linearVelocity.y;

        // 플레이어 바닥에서 Raycast
        Vector3 rayOrigin = new Vector3(
            playerBounds.center.x,
            playerBounds.min.y+0.3f,
            playerBounds.center.z
        );

        // 10번 레이어(Platform) 감지
        // 아래 방향으로 Raycast를 쏴서 플랫폼이 있는지 확인
        bool isPlatformBelow = Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, 0.8f, LayerMask.GetMask("Platform"));

        // 플랫폼과 플레이어의 충돌 처리
        if (vy > 0f || playerBottom < platformTop + yMargin && !isPlatformBelow)
        {
            // 플레이어가 위로 이동 중이거나 플랫폼 상단보다 아래에 있고, 플랫폼이 아래에 있는 경우 충돌 무시
            Physics.IgnoreCollision(playerCollider, platformCollider, true);
        }
        else
        {
            // 낙하 중이고 플랫폼보다 충분히 위 → 충돌 허용
            Physics.IgnoreCollision(playerCollider, platformCollider, false);
        }
    }
}
