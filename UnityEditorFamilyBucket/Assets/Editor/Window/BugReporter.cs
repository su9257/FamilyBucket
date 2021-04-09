using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using UnityEditor.SceneManagement;

public class BugReporter : EditorWindow
{

    string bugReportTitle = "";
    GameObject buggyGameObject;
    string description = "";

    [MenuItem("EditorTest/Bug Reporter")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(BugReporter));
    }

    public static EditorWindow ShowWindow2()
    {
        return EditorWindow.GetWindow(typeof(BugReporter));
    }

    public BugReporter()
    {
        titleContent = new GUIContent("BugReporter");
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();

        #region first

        GUILayout.Space(10);

        GUI.skin.label.fontSize = 24;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUILayout.Label("Bug Reporter");
        GUI.skin.label.fontSize = 12;
        GUI.skin.label.alignment = TextAnchor.UpperLeft;

        #endregion

        #region second

        GUILayout.Space(10);
        bugReportTitle = EditorGUILayout.TextField("Bug Title", bugReportTitle);

        GUILayout.Space(10);
        GUILayout.Label("Scene : " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        GUILayout.Space(10);
        GUILayout.Label("Time : " + System.DateTime.Now);

        #endregion

        #region third
        GUILayout.Space(10);
        buggyGameObject = (GameObject)EditorGUILayout.ObjectField("Buggy GameObject", buggyGameObject, typeof(GameObject), true);
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Description ", GUILayout.MaxWidth(80));
        description = EditorGUILayout.TextArea(description, GUILayout.MaxHeight(75));
        GUILayout.EndHorizontal();
        #endregion

        #region fourth
        GUILayout.Space(10);
        if (GUILayout.Button("Save Bug"))
        {
            SaveBug();
            AssetDatabase.Refresh();
        }
        #endregion

        #region fifth
        GUILayout.Space(10);
        if (GUILayout.Button("Save Bug With Screenshot"))
        {
            SaveBugWithScreenshot();
            AssetDatabase.Refresh();
        }
        #endregion

        EditorGUILayout.EndVertical();
    }

    void SaveBug()
    {
        Directory.CreateDirectory("Assets/BugReports/" + bugReportTitle);
        StreamWriter sw = new StreamWriter("Assets/BugReports/" + bugReportTitle + "/" + bugReportTitle + ".txt");
        sw.WriteLine(bugReportTitle);
        sw.WriteLine(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        sw.WriteLine(System.DateTime.Now.ToString());
        sw.WriteLine(description);
        sw.Close();
    }

    void SaveBugWithScreenshot()
    {
        Directory.CreateDirectory("Assets/BugReports/" + bugReportTitle);
        StreamWriter sw = new StreamWriter("Assets/BugReports/" + bugReportTitle + "/" + bugReportTitle + ".txt");
        sw.WriteLine(bugReportTitle);
        sw.WriteLine(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        sw.WriteLine(System.DateTime.Now.ToString());
        sw.WriteLine(description);
        sw.Close();
        ScreenCapture.CaptureScreenshot("Assets/BugReports/" + bugReportTitle + "/" + bugReportTitle + "Screenshot.png");
    }

}