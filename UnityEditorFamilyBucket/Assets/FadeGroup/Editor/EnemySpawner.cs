using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

public class EnemySpawner : EditorWindow
{
    GameObject enemyPrefab;
    AnimBool customizeValues;

    //Default values when opening window
    float enemyScale = 1f;
    int baseHP = 100;
    float baseSpeed = 5f;

    [MenuItem("EditorTest/Enemy Spawner")]
    private static void ShowWindow()
    {
        GetWindow(typeof(EnemySpawner));
    }

    private void OnEnable()
    {
        customizeValues = new AnimBool(false);
        customizeValues.valueChanged.AddListener(Repaint);
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn New Enemy", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        enemyPrefab = EditorGUILayout.ObjectField("Enemy Prefab", enemyPrefab, typeof(GameObject), false) as GameObject;

        customizeValues.target = EditorGUILayout.ToggleLeft("Customize Values", customizeValues.target);

        //Debug.Log($"customizeValues.faded:{customizeValues.faded}");
        if (EditorGUILayout.BeginFadeGroup(customizeValues.faded))
        {
            EditorGUI.indentLevel++;

            enemyScale = EditorGUILayout.FloatField("Size Scale", enemyScale);
            baseHP = EditorGUILayout.IntField("Base Health", baseHP);
            baseSpeed = EditorGUILayout.FloatField("Base Speed", baseSpeed);

            EditorGUI.indentLevel--;
        }
        else
        {
            // When toggle gets unchecked, revert to default vaules.
            baseHP = 100;
            enemyScale = 1f;
            baseSpeed = 5f;
        }
        EditorGUILayout.EndFadeGroup();

        EditorGUI.BeginDisabledGroup(enemyPrefab == null);

        if(GUILayout.Button("Spawn Enemy"))
        {
            SpawnEnemy();
        }

        EditorGUI.EndDisabledGroup();
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), Random.Range(-3.5f, 3.5f), 0f);

        GameObject newObject = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        newObject.name = (customizeValues.target ? "Custom" : "Default") + " Enemy";
        newObject.transform.localScale = Vector3.one * enemyScale;

        EnemyController curEnemyController = newObject.GetComponent<EnemyController>();
        curEnemyController.baseHealth = baseHP;
        curEnemyController.baseSpeed = baseSpeed;
        curEnemyController.SetTextLabels();
    }
}
