using UnityEngine;
using System.Collections;
using UnityEditor;

public class TextColorwindow : EditorWindow
{

    [MenuItem("EditorTest/文本颜色窗口")]
    public static void showWindow()
    {
        EditorWindow.GetWindow<TextColorwindow>().Show();
    }

    public string mText = "please input a string";

    public Color mColor = Color.black;


    public void OnGUI()
    {
        this.mText = EditorGUILayout.TextField(this.mText);
        this.mText = EditorGUILayout.TextArea(this.mText);//可以换行
        this.mText = EditorGUILayout.PasswordField(this.mText);

        this.mColor = EditorGUILayout.ColorField(this.mColor);
    }

}
