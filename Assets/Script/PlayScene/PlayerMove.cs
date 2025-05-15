using System;
using Unity.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Player player;  // Player 스크립트 연결
    bool isInitialized = false; // 초기화 여부

    // 플레이어 움직임 관련 변수 & 상태
    public float jumpForce = 17f;
    [ReadOnly] public bool isJumped = false;    // 점프 상태 (낙하 중 점프 가능 여부 체크 변수)
    [ReadOnly] public bool isSliding = false;
    [ReadOnly] public bool isGrounded = false;

    private bool jumpedByInput = false; // 플레이어 공중에 있을 때 점프 입력 여부
    
//
    public void Init(Player player) 
    {
        this.player = player;
        isInitialized = true;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            if (OnSlideInput()){
                player.SetState(PlayerState.Sliding);
            } else {
                player.SetState(PlayerState.Running);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
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
        
        // 동작
        HandleMovement();
        // 상태 평가
        EvaluateState(); 
    }

    void EvaluateState() {
        // 상태에 따라서 변수 설정
        // 구현 예정
        PlayerState state = player.GetState();
        if (state == PlayerState.Running) {
            isJumped = false;
            isGrounded = true;
            isSliding = false;
        } else if (state == PlayerState.Jumping) {
            isJumped = true;
            isGrounded = false;
            isSliding = false;
        } else if (state == PlayerState.Sliding){
            isJumped = false;
            isGrounded = true;
            isSliding = true;
        } else if (state == PlayerState.Falling) {
            isJumped = false;
            isGrounded = false;
            isSliding = false;
        } 
        // Death 상태는 따로 처리하지 않음
    }

    void HandleMovement() 
    {
        // 키 입력 처리
        if (OnJumpInput()) HandleJump();
        HandleSlide();  // 슬라이딩은 항상 체크
    }

    /*
    * 핸들러
    */
    void HandleJump() 
    {
        if (!CanJump()) return;

        // 슬라이딩중 점프시 슬라이딩 상태 초기화
        player.rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        player.SetState(PlayerState.Jumping);
        jumpedByInput = true; // 점프 입력 상태로 변경
        // 구현 예정
    }

    void HandleSlide() 
    {
        if (OnSlideInput())
        {
            if (!isSliding && CanSlide())
            {
                player.SetState(PlayerState.Sliding);
            }
        }
        else
        {
            if (isSliding)
            {
                player.SetState(PlayerState.Running);
            }
        }
    }

    
    /* 
    * 상태 체크
    */

    bool CanJump() 
    {
        if (!isJumped) { // 조건이 추가될 수 있음
            return true;
        }
        return false;
    }
    bool CanSlide() 
    {
        if (isGrounded) { // 조건이 추가될 수 있음
            return true;
        }
        return false;
    }

    /*
    * 입력 감지 함수
    */

    bool OnJumpInput(){
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
    }

    bool OnSlideInput(){
        return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
    }
}
