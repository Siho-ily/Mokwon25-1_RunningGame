using UnityEngine;

public class PlatformOneWay : MonoBehaviour
{
    private Collider playerCollider;
    private Collider platformCollider;

    private bool isIgnoring = false;

    [Header("충돌 무시 감지 설정")]
    [SerializeField] private float yMargin = 0.05f;  // 수직 감지 여유
    [SerializeField] private float xMargin = 0.2f;   // 수평 감지 여유

    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            playerCollider = playerObj.GetComponent<Collider>();

        platformCollider = GetComponent<Collider>();

        // 🔒 플랫폼이 Platform 레이어가 아닐 경우 자동으로 무시 대상에서 제외
        if (gameObject.layer != LayerMask.NameToLayer("Platform"))
        {
            Debug.LogWarning("이 오브젝트는 Platform 레이어가 아니므로 PlatformOneWay 작동 안함");
            this.enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (playerCollider == null || platformCollider == null) return;

        Bounds playerBounds = playerCollider.bounds;
        Bounds platformBounds = platformCollider.bounds;

        float playerBottom = playerBounds.min.y;
        float platformTop = platformBounds.max.y;

        float platformLeft = platformBounds.min.x;
        float platformRight = platformBounds.max.x;
        float playerX = playerBounds.center.x;

        bool isBelow = playerBottom < platformTop - yMargin;
        bool isBeside = playerX < platformLeft - xMargin || playerX > platformRight + xMargin;

        // ① 아래 또는 옆에서 접근 → 충돌 무시
        if ((isBelow || isBeside) && !isIgnoring)
        {
            Physics.IgnoreCollision(playerCollider, platformCollider, true);
            isIgnoring = true;
            Debug.Log("충돌 무시 시작 (아래 또는 옆)");
        }

        // ② 플레이어가 완전히 위로 벗어났을 때만 충돌 다시 활성화
        bool hasPassedThrough = playerBottom > platformTop + yMargin;

        if (isIgnoring && hasPassedThrough)
        {
            Physics.IgnoreCollision(playerCollider, platformCollider, false);
            isIgnoring = false;
            Debug.Log("플랫폼 완전히 통과 → 충돌 다시 활성화");
        }
    }
}
