#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
#endif
/*
 * ReadOnlyAttribute.cs
 * 
 * 유니티에 리드온리 속성을 추가해주는 클래스
 * 코드 작성시 [ReadOnly] 속성을 붙이면 해당 변수를 읽기 전용으로 설정할 수 있음.
 * 
 * ReadOnlyDrawer.cs
 * 
 * ReadOnlyAttribute를 사용하기 위한 CustomPropertyDrawer 클래스
 * OnGUI 메서드를 오버라이드하여 GUI.enabled를 false로 설정하여 읽기 전용으로 만듦.
 * 
 * 사용 예시:
 * [ReadOnly] public float jumpForce = 5f;
 */