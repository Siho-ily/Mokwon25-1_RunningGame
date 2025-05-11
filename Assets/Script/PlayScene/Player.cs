using UnityEngine;

[RequireComponent(typeof(PlayerMove), typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField, ReadOnly] private PlayerState state = PlayerState.Running; // 플레이어 상태
    public BoxCollider playerCollider; // 플레이어의 BoxCollider
    public Rigidbody rb; // 플레이어의 Rigidbody

    void Awake()
    {
        //PlayerMove에 참조 넘기기
        PlayerMove moveComponent = GetComponent<PlayerMove>();
        moveComponent.Init(this);
    }

    // 전이 함수
    public void SetState(PlayerState newState)
    {
        if (state == PlayerState.Death) return; // 죽으면 상태 변경 금지
        state = newState;
    }

    public PlayerState GetState() {
        return state;
    }
}
