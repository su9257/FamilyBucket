using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(Player))]
//[CanEditMultipleObjects]
public class PlayerInspector_1 : Editor
{
    Player player;
    SerializedProperty playerName;
    SerializedProperty playerHealth;
    SerializedProperty HL;
    private void OnEnable()
    {
        player = (Player)target;
        playerName = serializedObject.FindProperty("playerName");
        playerHealth = serializedObject.FindProperty("health");
        HL = serializedObject.FindProperty("HL");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.BeginVertical();

        EditorGUILayout.PropertyField(playerName);


        if (playerHealth.floatValue < 20)
        {
            GUI.color = Color.red;
        }
        if (playerHealth.floatValue > 80)
        {
            GUI.color = Color.green;
        }
        EditorGUILayout.PropertyField(playerHealth);
        GUI.color = Color.white;
        EditorGUILayout.PropertyField(HL);
        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }
}
