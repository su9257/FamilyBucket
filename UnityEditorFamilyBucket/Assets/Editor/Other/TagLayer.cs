using System;
using UnityEngine;
using System.Collections;
using UnityEditor;

public class TagLayer : EditorWindow
{

    [MenuItem("EditorTest/标签、层、对象选择")]
    public static void showWindow()
    {
        EditorWindow.GetWindow<TagLayer>().Show();
    }

    public String mTag;

    public int mLayer;

    public UnityEngine.Object mObject;

    public void OnGUI()
    {
        mTag = EditorGUILayout.TagField(this.mTag);

        mLayer = EditorGUILayout.LayerField(this.mLayer);

        mObject = EditorGUILayout.ObjectField(this.mObject, typeof(UnityEngine.Object),true);
    }


}
