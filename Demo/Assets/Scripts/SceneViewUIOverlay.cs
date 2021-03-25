using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

// Display a zoom indicator overlay on the 2D scene view.  Click it to reset to 100% zoom
[InitializeOnLoad]
public static class SceneViewUIOverlay
{
    static GUIStyle buttonStyle = new GUIStyle();

    static SceneViewUIOverlay()
    {
        SceneView.duringSceneGui += OnSceneGUI;
        buttonStyle.normal.textColor = Color.white;

    }

    static void OnSceneGUI(SceneView sceneView)
    {
        if (!sceneView.in2DMode)
            return;
       
        // Calculate current zoom level
        float zoom = GetSceneViewHeight(sceneView) / (sceneView.camera.orthographicSize * 2f);

        // Display zoom indicator in top left corner; clicking the indicator resets to 100%
        Handles.BeginGUI();
        if (GUI.Button(new Rect(5, 5, 50, buttonStyle.lineHeight), $"{zoom * 100:N0}%", buttonStyle))
            SetSceneViewZoom(sceneView, 1f);
        Handles.EndGUI();
    }

    static float GetSceneViewHeight(SceneView sceneView)
    {
        // Don't use sceneView.position.height, as it does not account for the space taken up by
        // toolbars.
        return sceneView.position.width / sceneView.camera.aspect;
    }

    static void SetSceneViewZoom(SceneView sceneView, float zoom)
    {
        float orthoHeight = GetSceneViewHeight(sceneView) / 2f / zoom;

        // We can't set camera.orthographicSize directly, because SceneView overrides it
        // every frame based on SceneView.size, so set SceneView.size instead.
        //
        // See SceneView.GetVerticalOrthoSize for the source of these sqrts.
        //sceneView.size = orthoHeight * Mathf.Sqrt(2f) * Mathf.Sqrt(sceneView.camera.aspect);
        float size = orthoHeight * Mathf.Sqrt(2f) * Mathf.Sqrt(sceneView.camera.aspect);
        sceneView.LookAt(sceneView.pivot, sceneView.rotation, size);
    }
}