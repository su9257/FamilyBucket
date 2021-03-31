using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class StartWindow : EditorWindow
{
    public enum Size
    {
        Small,
        Medium,
        Large
    }

    private Size blueSize;
    private Size greenSize;
    private Size yellowSize;

    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D warriorSectionTexture;
    Texture2D rogueSectionTexture;
    Texture2D mageTexture;

    Color headerSectionColor = new Color(13f / 255f, 32f / 255f, 44f / 255f, 1f);

    Rect headerSection;
    Rect mageerSection;
    Rect warriorSection;
    Rect rogueSection;
    Rect mageIconSection;

    float iconSize = 50;

    GUISkin guiSkin;
    [MenuItem("EditorTest/OpenStartWindow")]
    static void OpenWindow()
    {
        var window = GetWindow<StartWindow>();
        window.minSize = new Vector2(600, 300);
        window.maxSize = new Vector2(1200, 600);
    }

    private void OnEnable()
    {
        InitTextures();
        InitData();
        guiSkin = Resources.Load<GUISkin>("New GUISkin");
    }

    private void InitTextures()
    {
        headerSectionTexture = new Texture2D(1, 1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();

        mageSectionTexture = Resources.Load<Texture2D>("Icons/blue");
        warriorSectionTexture = Resources.Load<Texture2D>("Icons/yellow");
        rogueSectionTexture = Resources.Load<Texture2D>("Icons/green");

        mageTexture = Resources.Load<Texture2D>("Icons/star");
    }

    private void InitData()
    {

    }

    void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawMageSettings();
        DrawWarriorSettings();
        DrawRogueSettings();
    }

    private void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 50;
        GUI.DrawTexture(headerSection, headerSectionTexture);

        mageerSection.x = 0;
        mageerSection.y = 50;
        mageerSection.width = Screen.width / 3f;
        mageerSection.height = Screen.width - 50;
        GUI.DrawTexture(mageerSection, mageSectionTexture);

        warriorSection.x = (Screen.width / 3f);
        warriorSection.y = 50;
        warriorSection.width = Screen.width / 3f;
        warriorSection.height = Screen.width - 50;
        GUI.DrawTexture(warriorSection, warriorSectionTexture);

        rogueSection.x = (Screen.width / 3f) * 2;
        rogueSection.y = 50;
        rogueSection.width = Screen.width / 3f;
        rogueSection.height = Screen.width - 50;
        GUI.DrawTexture(rogueSection, rogueSectionTexture);


        mageIconSection.x = (mageerSection.x + mageerSection.width / 2f) - iconSize/2;
        mageIconSection.y = mageerSection.y + 100;
        mageIconSection.width = iconSize;
        mageIconSection.height = iconSize;
        GUI.DrawTexture(mageIconSection, mageTexture);
    }

    private void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);
        GUILayout.Label("Header", guiSkin.GetStyle("Header"));
        GUILayout.EndArea();
    }

    private void DrawMageSettings()
    {
        GUILayout.BeginArea(mageerSection);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Mage");
        blueSize = (Size)EditorGUILayout.EnumPopup(blueSize);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.MAGE);
        }

        GUILayout.EndArea();
    }

    private void DrawWarriorSettings()
    {
        GUILayout.BeginArea(warriorSection);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Warrior");
        yellowSize = (Size)EditorGUILayout.EnumPopup(yellowSize);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.WARRIOR);
        }

        GUILayout.EndArea();
    }



    private void DrawRogueSettings()
    {
        GUILayout.BeginArea(rogueSection);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Rogue");
        greenSize = (Size)EditorGUILayout.EnumPopup(greenSize);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.ROGUE);
        }

        GUILayout.EndArea();
    }
}


public class GeneralSettings : EditorWindow
{
    public enum SettingsType
    {
        MAGE, WARRIOR, ROGUE
    }

    static SettingsType dataSettting;
    static GeneralSettings window;
    public static void OpenWindow(SettingsType setting)
    {
        dataSettting = setting;
        window = GetWindow<GeneralSettings>();
        window.minSize = new Vector2(250, 200);
    }

    private void OnGUI()
    {
        switch (dataSettting)
        {
            case SettingsType.MAGE:
                DrawSettings(SettingsType.MAGE.ToString());
                break;
            case SettingsType.WARRIOR:
                DrawSettings(SettingsType.WARRIOR.ToString());
                break;
            case SettingsType.ROGUE:
                DrawSettings(SettingsType.ROGUE.ToString());
                break;
            default:
                break;
        }
    }

    float percent = 0;
    private void DrawSettings(string name)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("显示面板");
        var str1 = EditorGUILayout.TextField(name);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Prefab");

        tempTexture = EditorGUILayout.ObjectField(tempTexture, typeof(Texture2D), false) as Texture2D;

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("内容");
        EditorGUILayout.TextField(tempstr_1);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginVertical("Box");
        GUILayout.Label("显示百分比 %");
        percent = EditorGUILayout.Slider(percent, -100, 100);
        EditorGUILayout.EndVertical();

        if (tempTexture == null)
        {
            EditorGUILayout.HelpBox("需要设置对应的Prefab", MessageType.Warning);
        }
        else if (GUILayout.Button("关闭", GUILayout.Height(30)))
        {
            window.Close();
            SaveAssetData();
        }
    }

    public string tempstr_1;
    public Texture2D tempTexture;

    private void SaveAssetData()
    {
        var prefabPath = AssetDatabase.GetAssetPath(tempTexture);
        Debug.Log(prefabPath);
        string newPrefabPath = Path.Combine(Application.dataPath, "newPng.png");
        var isSuccessful = AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
        AssetDatabase.SaveAssets();
        Debug.Log(isSuccessful + newPrefabPath);
        AssetDatabase.Refresh();
    }


}
