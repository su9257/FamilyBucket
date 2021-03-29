using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.Utilities;

/// <summary>
/// Adds the given define symbols to PlayerSettings define symbols.
/// Just add your own define symbols to the Symbols property at the below.
/// </summary>
public class OneKeyChangeDefineSymbols : SerializedScriptableObject
{

    /// <summary>
    /// Symbols that will be added to the editor
    /// </summary>
    public string[] Symbols = new string[] {
         "MYCOMPANY",
         "MYCOMPANY_MYPACKAGE"
     };

    [Button("生成")]
    public void Build()
    {
        string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
        List<string> allDefines = definesString.Split(';').ToList();
        allDefines.AddRange(Symbols.Except(allDefines));
        PlayerSettings.SetScriptingDefineSymbolsForGroup(
            EditorUserBuildSettings.selectedBuildTargetGroup,
            string.Join(";", allDefines.ToArray()));
    }

    public List<string> testDefine = new List<string>();
    [Button("TestButton", ButtonSizes.Gigantic)]
    public void TestButton()
    {
        string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
        List<string> allDefines = definesString.Split(';').ToList();
        testDefine.AddRange(allDefines);
    }

    public string temp;

}