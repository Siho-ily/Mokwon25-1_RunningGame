using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    private Player player;  // Player 스크립트 연결
    bool isInitialized = false; // 초기화 여부

    // 플레이어 움직임 관련 변수 & 상태
    [SerializeField, ReadOnly] public float jumpForce = 17f;    // 점프 강도
    [ReadOnly] public bool isJumped = false;                    // 점프 상태 (낙하 중 점프 가능 여부 체크 변수)
    [ReadOnly] public bool isSliding = false;                   // 슬라이딩 여부부
    [ReadOnly] public bool isGrounded = false;                  // 땅에 닿았는지 여부

    private bool jumpedByInput = false;                         // 플레이어 공중에 있을 때 점프 입력 여부

    //
    public void Init(Player player)
    {   // 초기화 코드
        this.player = player;
        isInitialized = true;
    }

    void OnCollisionEnter(Collision collision)
    {   // 플레이어가 착지했을 때, 슬라이딩 or 러닝 상태 설정
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            if (OnSlideInput())
            {
                player.SetState(PlayerState.Sliding);
            }
            else
            {
                player.SetState(PlayerState.Running);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {   // 플레이어가 땅에서 떨어졌을 때, 점프상태인지 확인 후 상태 설정
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            if (jumpedByInput)
            {
                jumpedByInput = false; // 리셋
                // 이미 Jumping 상태이므로 상태 변경 필요 없음
            }
            else
            {
                player.SetState(PlayerState.Falling); // 사용자가 점프 안하고 떨어지는 중
            }
        }
    }

    void Update()
    {
        if (!isInitialized) return; // 초기화가 안되어있으면 아무것도 하지 않음
        if (player.GetState() == PlayerState.Death) return; // 죽은 상태라면 아무것도 하지 않음

        // 동작 핸들러
        HandleMovement();
        // 상태 변경 핸들러
        EvaluateState();
    }

    void EvaluateState()
    {
        // 상태에 따라서 변수 설정
        PlayerState state = player.GetState();
        if (state == PlayerState.Running)
        {
            isJumped = false;
            isGrounded = true;
            isSliding = false;
        }
        else if (state == PlayerState.Jumping)
        {
            isJumped = true;
            isGrounded = false;
            isSliding = false;
        }
        else if (state == PlayerState.Sliding)
        {
            isJumped = false;
            isGrounded = true;
            isSliding = true;
        }
        else if (state == PlayerState.Falling)
        {
            isJumped = false;
            isGrounded = false;
            isSliding = false;
        }
        // Death 상태는 따로 처리하지 않음
    }

    /*
    * 핸들러
    */
    void HandleMovement()
    {   // 움직임 처리 핸들러러
        // 점프 키 입력 처리
        if (OnJumpInput()) HandleJump();
        // 슬라이딩은 항상 체크
        HandleSlide();  
    }

    void HandleJump()
    {   // 점프 처리 핸들러
        // 점프가 불가능하면 아무 일도 안함함
        if (!CanJump()) return;

        // 점프
        player.rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        player.SetState(PlayerState.Jumping);   // 플레이어 상태 점프중으로 변경
        jumpedByInput = true;                   // 점프 입력 상태로 변경
    }

    void HandleSlide()
    {   // 슬라이딩 처리 핸들러러
        // 슬라이딩 키를 누르고 있을 경우
        if (OnSlideInput())
        {   // 슬라이딩 중이 아니면서 슬라이딩이 가능한 상황이면
            if (!isSliding && CanSlide())
            {   // 플레이어의 상태를 슬라이딩으로 변경
                player.SetState(PlayerState.Sliding);
            }
        }
        else
        {   // 슬라이딩이 되어 있을 경우
            if (isSliding)
            {   // 플레이어의 상태를 러닝으로 변경
                player.SetState(PlayerState.Running);
            }
        }
    }


    /* 
    * 상태 체크
    */

    // 점프가 가능한지 확인하는 메소드
    bool CanJump()
    {   // 점프를 했으면 불가능능
        if (!isJumped)
        {
            return true;
        }
        return false;
    }

    // 슬라이딩이 가능한지 확인하는 메소드
    bool CanSlide()
    {   // 땅에 닿아있지 않으면 불가능
        if (isGrounded)
        {
            return true;
        }
        return false;
    }

    /*
    * 입력 감지 함수
    */

    bool OnJumpInput()
    {   // 스페이스바, W, 위쪽 화살표
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
    }

    bool OnSlideInput()
    {   // 왼쪽 쉬프트, S, 아래쪽 화살표
        return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
    }
}
