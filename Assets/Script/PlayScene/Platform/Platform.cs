using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Component")]
    public Collider platformCollider;           // 플랫폼 콜라이더
    public PlatformMove moveComponent;          // 플랫폼 이동 스크립트 컴포넌트
    public PlatformOneWay oneWayComponent;      // 플랫폼 일방향 활성화 스크립트 컴포넌트

}