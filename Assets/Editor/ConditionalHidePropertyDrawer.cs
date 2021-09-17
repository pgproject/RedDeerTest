using System.Threading;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
public class ConditionalHidePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ConditionalHideAttribute conditionalHideAttribute = (ConditionalHideAttribute) attribute;
        bool enabled = GetConditionalHideAttributeResult(conditionalHideAttribute, property);

        bool wasEnabled = GUI.enabled;
        GUI.enabled = enabled;

        if (!conditionalHideAttribute.HideInInspector || enabled)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ConditionalHideAttribute conditionalHideAttribute = (ConditionalHideAttribute) attribute;
        bool enabled = GetConditionalHideAttributeResult(conditionalHideAttribute, property);

        if (!conditionalHideAttribute.HideInInspector || enabled)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }
        else
        {
            return -EditorGUIUtility.standardVerticalSpacing;
        }
    }

    private bool GetConditionalHideAttributeResult(ConditionalHideAttribute conditionalHideAttribute, SerializedProperty property)
    {
        bool enabled = true;
        string propertyPath = property.propertyPath;
        string conditionPath = propertyPath.Replace(property.name, conditionalHideAttribute.ConditionalSourceField);

        SerializedProperty serializedProperty = property.serializedObject.FindProperty(conditionPath);

        if (serializedProperty != null)
        {
            enabled = serializedProperty.boolValue;
        }
        else
        {
            Debug.LogWarning("Attempting to use a ConditionalHideAttribute but no matching serializedProperty found in object");
        }

        return enabled;
    }
    
}
