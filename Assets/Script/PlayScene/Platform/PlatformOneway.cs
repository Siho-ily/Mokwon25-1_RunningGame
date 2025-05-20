using UnityEngine;

[RequireComponent(typeof(Platform))]
public class PlatformOneWay : MonoBehaviour
{
    private bool isInitialized = false;
    private bool isIgnoring = false;

    [Header("Component")]
    public Player player;
    public Platform platform;
    private GameObject playerObj;
    private Collider playerCollider;
    public Collider platformCollider;

    [Header("충돌 무시 감지 설정")]
    [SerializeField] private float yMargin = 0.05f;  // 수직 감지 여유
    [SerializeField] private float xMargin = 0.2f;   // 수평 감지 여유


    public void Init(Platform platform)
    {   // 초기화 코드
        isInitialized = true;
        this.platform = platform;
    }

    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<Player>();
            playerCollider = player.playerCollider;
        }
    }

	void Update()
	{
        if (!isInitialized) return;
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
        if ((isBelow || isBeside) && !isIgnoring && platformCollider.CompareTag("Platform"))
        {
            Physics.IgnoreCollision(playerCollider, platformCollider, true);
            isIgnoring = true;
            Debug.Log("충돌 무시 시작 (Platform만): " + platformCollider.name);
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
