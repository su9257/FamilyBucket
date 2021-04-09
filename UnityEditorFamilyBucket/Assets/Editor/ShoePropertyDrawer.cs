using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Shoe))]
public class ShoePropertyDrawer : PropertyDrawer
{
    Rect top, middleLeft, middleRight, bottom;
    SerializedProperty shoeName, shoeType, size, description;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 4.0f;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        top = new Rect(position.x, position.y, position.width, position.height / 4.0f);

        middleLeft = new Rect(
            position.x,
            position.y + (position.height / 4.0f),
            position.width / 2.0f,
            position.height / 4.0f);

        middleRight = new Rect(
            position.x + position.width / 2.0f,
            position.y + (position.height / 4.0f),
            position.width / 2.0f,
            position.height / 4.0f);

        bottom = new Rect(position.x, position.y + (position.height / 4.0f) * 2, position.width, position.height/2);

        shoeName = property.FindPropertyRelative("name");
        shoeType = property.FindPropertyRelative("shoeType");
        size = property.FindPropertyRelative("size");
        description = property.FindPropertyRelative("description");

        EditorGUI.PropertyField(top, shoeName);
        EditorGUI.PropertyField(middleLeft, shoeType);
        EditorGUI.PropertyField(middleRight, size);

        description.stringValue = EditorGUI.TextArea(bottom, description.stringValue);
    }
}
