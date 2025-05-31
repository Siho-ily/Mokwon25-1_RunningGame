using UnityEngine;

[RequireComponent(typeof(PlayerMove), typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("State")]
    [SerializeField, ReadOnly] private PlayerState state = PlayerState.Running; // 플레이어 상태

    [Header("Component")]
    public BoxCollider playerCollider; // 플레이어의 BoxCollider
    public Rigidbody rb; // 플레이어의 Rigidbody
    public PlayerMove moveComponent;    // 플레이어 움직임 컴포넌트

    void Awake()
    {   // Player 객체 PlayerMove 전달
        moveComponent.Init(this);
    }

    // 전이 함수
    // 플레이어의 현재 상태를 변경하는는 함수
    public void SetState(PlayerState newState)
    {
        if (state == PlayerState.Death) return; // 죽으면 상태 변경 금지
        state = newState;
    }
    // 플레이어의 현재 상태를 가져오는 함수
    public PlayerState GetState() {
        return state;
    }
}
