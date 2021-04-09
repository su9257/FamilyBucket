using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

[CustomEditor(typeof(Player))]
[CanEditMultipleObjects]
public class PlayerInspector : Editor
{

    Player player;
    bool showWeapons;
    AnimBool customizeValues;
    private void OnEnable()
    {
        player = (Player)target;

        showWeapons = false;

        customizeValues = new AnimBool(false);
        customizeValues.valueChanged.AddListener(Repaint);
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();

        EditorGUILayout.LabelField("Player  ID" + player.id);
        player.playerName = EditorGUILayout.TextField("Player Name", player.playerName);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Back Story");
        player.backStory = EditorGUILayout.TextArea(player.backStory, GUILayout.MinHeight(50));


        if (player.health < 20)
        {
            GUI.color = Color.red;
        }
        else if (player.health > 75)
        {
            GUI.color = Color.green;
        }
        else
        {
            GUI.color = Color.yellow;
        }

        Rect progressRect = GUILayoutUtility.GetRect(50, 50);
        EditorGUI.ProgressBar(progressRect, player.health / 100f, "Health");

        player.health = EditorGUILayout.FloatField("Health", player.health);
        GUI.color = Color.white;

        EditorGUILayout.Space(20, true);
        player.damage = EditorGUILayout.Slider("Damage", player.damage, 10, 20);

        if (player.damage < 12)
        {
            EditorGUILayout.HelpBox("The damage is too low!", MessageType.Warning);
        }
        if (player.damage > 18)
        {
            EditorGUILayout.HelpBox("The damage is too High!", MessageType.Warning);
        }

        EditorGUILayout.Space(20, true);

        showWeapons = EditorGUILayout.Foldout(showWeapons, "显示武器");
        if (showWeapons)
        {
            EditorGUI.indentLevel += 2;
            player.weapon1Damage = EditorGUILayout.FloatField("weapon1Damage", player.weapon1Damage);
            player.weapon2Damage = EditorGUILayout.FloatField("weapon2Damage", player.weapon2Damage);
            EditorGUI.indentLevel -= 2;
        }

        customizeValues.target = EditorGUILayout.ToggleLeft("Customize Values", customizeValues.target);
        if (EditorGUILayout.BeginFadeGroup(customizeValues.faded))
        {
            EditorGUI.indentLevel += 2;
            player.weapon1Damage = EditorGUILayout.FloatField("weapon2Damage", player.weapon1Damage);
            player.weapon2Damage = EditorGUILayout.FloatField("weapon2Damage", player.weapon2Damage);

            EditorGUI.indentLevel -= 2;
        }
        EditorGUILayout.EndFadeGroup();

        EditorGUILayout.LabelField("Shoe");

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Name", GUILayout.MaxWidth(50));
        player.shoeName = EditorGUILayout.TextField(player.shoeName);
        EditorGUILayout.LabelField("Size", GUILayout.MaxWidth(50));
        player.shoeSize = EditorGUILayout.IntField(player.shoeSize);
        EditorGUILayout.LabelField("Type", GUILayout.MaxWidth(50));
        player.shoeType = EditorGUILayout.TextField(player.shoeType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Do Something"))
        {
            Debug.Log("触发按钮Do Something");
        }

        EditorGUILayout.EndVertical();

    }
}
