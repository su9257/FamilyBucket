using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

[CanEditMultipleObjects]//允许选中多个object进行inspector上的操作
[CustomEditor(typeof(InspectorExample_0))]
public class InspectorExample_0_Drawer : Editor
{
    private InspectorExample_0 inspectorExample;
    private AnimBool foldoutAnimBool;
    private bool foldoutToggle;
    private SerializedProperty privateFieldContent;
    private bool allowModifyReadOnly;

    private Vector2 scrollPos;
    private string scrollContent =@"你好，欢迎来到我的博客！
我是海澜，
一名从事Unity游戏开发的野生程序员。";
    private void OnEnable()
    {
        inspectorExample = (InspectorExample_0)target;
        foldoutAnimBool = new AnimBool(false);
        foldoutAnimBool.valueChanged.AddListener(Repaint);
        foldoutToggle = false;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();

        EditorGUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.MaxHeight(100));
        GUILayout.Label(scrollContent);
        EditorGUILayout.EndScrollView();

        //按钮
        EditorGUILayout.BeginVertical();
        ColorUtility.TryParseHtmlString("#12FFE9", out Color color);
        GUI.color = color;
        if (GUILayout.Button("点击详见更多内容", GUILayout.MinHeight(50)))
        {
            Application.OpenURL("https://aihailan.com/%e9%9d%a9%e5%91%bd%e6%80%a7unity-%e7%bc%96%e8%be%91%e5%99%a8%e6%89%a9%e5%b1%95%e5%b7%a5%e5%85%b7-odininspector%e7%b3%bb%e5%88%97%e6%95%99%e7%a8%8b/");
        }
        GUI.color = Color.white;

        EditorGUILayout.Space(20);

        if (GUILayout.Button("Github工程下载", GUILayout.MinHeight(50)))
        {
            Application.OpenURL("https://github.com/su9257/FamilyBucket/tree/main/UnityEditorFamilyBucket");
        }
        GUI.color = Color.white;
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();

        //找到类中的私有字段
        serializedObject.Update();
        privateFieldContent = serializedObject.FindProperty("privateFieldContent");//私有字段只有添加SerializeField的才能找到
        EditorGUILayout.LabelField($"私有字段：{privateFieldContent.stringValue}");
        serializedObject.ApplyModifiedProperties();

        EditorGUILayout.IntField("ID", inspectorExample.id);
        EditorGUILayout.LabelField("描述内容");
        inspectorExample.description = EditorGUILayout.TextArea(inspectorExample.description, GUILayout.MinHeight(30));

        //警告
        EditorGUILayout.Space(20);
        inspectorExample.warningContent = EditorGUILayout.TextField("警告内容", inspectorExample.warningContent);
        EditorGUILayout.HelpBox(inspectorExample.warningContent, MessageType.Warning);

        //Slider滑动条
        EditorGUILayout.Space(20);
        inspectorExample.sliderIntValue = EditorGUILayout.IntSlider("int滑动条", inspectorExample.sliderIntValue, 0, 100);
        inspectorExample.sliderFloatValue = EditorGUILayout.Slider("float滑动条", inspectorExample.sliderFloatValue, 0, 100);
        EditorGUILayout.MinMaxSlider("Min&Max滑动条", ref inspectorExample.minValue, ref inspectorExample.maxValue, -100, 200, GUILayout.MinHeight(20));
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.FloatField(nameof(inspectorExample.minValue), inspectorExample.minValue);
        EditorGUILayout.FloatField(nameof(inspectorExample.maxValue), inspectorExample.maxValue);
        EditorGUILayout.EndHorizontal();

        //progressBar进度条
        EditorGUILayout.Space(20);
        inspectorExample.progressBarValue = EditorGUILayout.Slider(inspectorExample.progressBarValue, 0, 1);
        if (inspectorExample.progressBarValue <= 0.2f)
        {
            GUI.color = Color.red;
        }
        else if (inspectorExample.progressBarValue >= 0.8f)
        {
            GUI.color = Color.green;
        }
        else
        {
            GUI.color = Color.white;
        }
        Rect progressRect = GUILayoutUtility.GetRect(50, 50);
        EditorGUI.ProgressBar(progressRect, inspectorExample.progressBarValue, "进度条");
        GUI.color = Color.white;//恢复

        //条目列表
        EditorGUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        foldoutToggle = EditorGUILayout.ToggleLeft("显示条目", foldoutToggle);
        foldoutToggle = EditorGUILayout.Foldout(foldoutToggle, "折叠", true);
        EditorGUILayout.EndHorizontal();
        if (foldoutToggle)
        {
            EditorGUI.indentLevel += 2;
            inspectorExample.item_0 = EditorGUILayout.TextField("item_0", inspectorExample.item_0);
            inspectorExample.item_1 = EditorGUILayout.TextField("item_1", inspectorExample.item_1);
            inspectorExample.item_2 = EditorGUILayout.TextField("item_2", inspectorExample.item_2);
            EditorGUI.indentLevel -= 2;
        }
        EditorGUILayout.Space(20);
        foldoutAnimBool.target = EditorGUILayout.ToggleLeft("缓动显示条目", foldoutAnimBool.target); ;
        if (EditorGUILayout.BeginFadeGroup(foldoutAnimBool.faded))
        {
            EditorGUI.indentLevel += 2;
            inspectorExample.item_0 = EditorGUILayout.TextField("item_0", inspectorExample.item_0);
            inspectorExample.item_1 = EditorGUILayout.TextField("item_1", inspectorExample.item_1);
            inspectorExample.item_2 = EditorGUILayout.TextField("item_2", inspectorExample.item_2);
            EditorGUI.indentLevel -= 2;
        }
        EditorGUILayout.EndFadeGroup();


        //只读条目
        EditorGUILayout.Space(20);
        allowModifyReadOnly = EditorGUILayout.BeginToggleGroup("允许修改只读参数", allowModifyReadOnly);
        EditorGUILayout.TextField(nameof(inspectorExample.readOnlyItem_0), inspectorExample.readOnlyItem_0);
        EditorGUILayout.TextField(nameof(inspectorExample.readOnlyItem_1), inspectorExample.readOnlyItem_1);
        EditorGUILayout.TextField(nameof(inspectorExample.readOnlyItem_2), inspectorExample.readOnlyItem_2);
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndVertical();
    }

}
