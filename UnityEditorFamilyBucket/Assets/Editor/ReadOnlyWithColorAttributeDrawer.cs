using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ReadOnlyWithColorAttribute))]
public class ReadOnlyWithColorAttributeDrawer : PropertyDrawer
{
    string value;
    Color inputColor;
    ReadOnlyWithColorAttribute readOnlyWithColorAttribute;
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        readOnlyWithColorAttribute = (ReadOnlyWithColorAttribute)attribute;
        inputColor = new Color(readOnlyWithColorAttribute.m_r, readOnlyWithColorAttribute.m_g, readOnlyWithColorAttribute.m_b);

        if (property.propertyType == SerializedPropertyType.Integer)
        {
            value = property.intValue.ToString();
        }
        if (property.propertyType == SerializedPropertyType.Float)
        {
            value = property.floatValue.ToString();
        }
        if (property.propertyType == SerializedPropertyType.String)
        {
            value = property.stringValue.ToString();
        }
        GUI.color = inputColor;
        GUI.Label(position, property.displayName + ":" + value);
        GUI.color = Color.white;
    }
}
