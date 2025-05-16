using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Platform : MonoBehaviour
{
    [Header("Component")]
    public Collider platformCollider;
    public PlatformMove moveComponent;
    public PlatformOneWay oneWayComponent;

    void Awake()
    {
        oneWayComponent.Init(this);
    }
}