using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(AI))]
public class AIInspector : Editor
{
    AI ai;
    private void OnEnable()
    {
        ai = (AI)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }

    private void OnSceneGUI()
    {
        Handles.Label(ai.transform.position + new Vector3(0, 1, 0), "Deadly AI:" + ai.name);

        ai.areaRadius = Handles.RadiusHandle(Quaternion.identity, ai.transform.position, ai.areaRadius);
        Handles.ScaleValueHandle(ai.speed, ai.transform.position, Quaternion.identity, ai.speed, Handles.ArrowHandleCap, 0.1f);

        if (ai.showNodeHandles)
        {
            for (int i = 0; i < ai.nodePoints.Length; i++)
            {
                ai.nodePoints[i] = Handles.PositionHandle(ai.nodePoints[i], ai.nodePointsRotations[i]);
                //ai.nodePoints[i] = Handles.PositionHandle(ai.nodePoints[i], Quaternion.Euler(0, 30, 0));

            }
        }

        for (int i = 0; i < ai.nodePoints.Length; i++)
        {
            Handles.DrawLine(ai.nodePoints[i], ai.nodePoints[(int)Mathf.Repeat(i + 1, ai.nodePoints.Length)]);
        }
        if (ai.showNodeHandles)
        {
            for (int i = 0; i < ai.nodePointsRotations.Length; i++)
            {
                ai.nodePointsRotations[i] = Handles.RotationHandle(ai.nodePointsRotations[i], ai.nodePoints[i]);
            }
        }
        
        Handles.BeginGUI();
        GUILayout.BeginVertical();

        GUILayout.BeginArea(new Rect(20, 20, 60, 500));


        if (GUILayout.Button("Test0",GUILayout.MinHeight(50), GUILayout.MaxWidth(100)))
        {
            Debug.Log("Test0");
        }

        if (GUILayout.Button("Test1", GUILayout.MinHeight(50), GUILayout.MaxWidth(100)))
        {
            Debug.Log("Test1");
        }

        if (GUILayout.Button("Test2", GUILayout.MinHeight(50), GUILayout.MaxWidth(100)))
        {
            Debug.Log("Test2");
        }

        if (GUILayout.Button("Test3", GUILayout.MinHeight(50), GUILayout.MaxWidth(100)))
        {
            Debug.Log("Test3");
        }


        GUILayout.EndArea();

        GUILayout.EndVertical();
        Handles.EndGUI();
    }
}
