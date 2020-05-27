using UnityEditor;
using UnityEngine;

namespace Utils.Editor
{
    [CustomPropertyDrawer(typeof(RequireInterfaceAttribute))]
    public class RequireInterfaceDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                EditorGUI.BeginProperty(position, label, property);
                {
                    var requiredAttribute = (RequireInterfaceAttribute)attribute;
                    property.objectReferenceValue = EditorGUI.ObjectField(position, label, property.objectReferenceValue, requiredAttribute.RequiredType, true);
                }
                EditorGUI.EndProperty();
            }
            else
            {
                var previousColor = GUI.color;
                {
                    GUI.color = Color.red;
                    EditorGUI.LabelField(position, label, new GUIContent("Property is not a reference type"));
                }
                GUI.color = previousColor;
            }
        }
    }
}
