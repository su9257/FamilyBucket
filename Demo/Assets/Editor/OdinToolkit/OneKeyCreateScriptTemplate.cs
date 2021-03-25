using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;
using System.Security;

[TypeInfoBox("<size=20>快速生成PureMVC所需模块脚本模板</size>")]
public class OneKeyCreateScriptTemplate : SerializedScriptableObject
{

    [InfoBox("<size=15>生成脚本存储的路径</size>")]
    [FolderPath(ParentFolder = "Assets/Scripts", AbsolutePath = true)]
    public string FilePath;

    const string k_Tab = "    ";
    const string PanelScriptInheritance = " : UIPanel, IRegisterAndRemoveComponent, IRegisterAndRemoveCommand, IRegisterAndRemoveMediator";
    const string MediatorInheritance = " : Mediator";

    const string CommandFileNamePrefix_Open = "LoadOrOpen";
    const string CommandFileNamePrefix_Close = "UnLoadOrClose";
    const string CommandlFileNameSuffix = "Command";

    #region 创建及验证相关

    void CreateScript(string fileName, string content)
    {
        string path = FilePath + "/" + fileName + ".cs";
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            using (StreamWriter writer = new StreamWriter(fs, System.Text.Encoding.UTF8))
            {
                writer.Write(content);
            }
        }
    }
    public string AdditionalNamespacesToString()
    {
        return
            "using System;\r\n" +
            "using System.Collections;\r\n" +
            "using System.Collections.Generic;\r\n" +
            "using System.IO;\r\n" +
            "using System.Linq;\r\n" +
            "using UnityEngine;\r\n" +
            "using UnityEngine.UI;\r\n" +
            "using UnityEngine.Timeline;\r\n" +
            "using PureMVC.Core;\r\n" +
            "using PureMVC.Interfaces;\r\n" +
            "using PureMVC.Patterns;\r\n" +
            "using PureMVC.Patterns.Command;\r\n" +
            "using PureMVC.Patterns.Facade;\r\n" +
            "using PureMVC.Patterns.Mediator;\r\n" +
            "using PureMVC.Patterns.Observer;\r\n" +
            "using PureMVC.Patterns.Proxy;\r\n" +
            "using Sirenix.OdinInspector; \r\n" +
            "using TMPro; \r\n" +
            "\r\n";
    }
    public string CreatePanelString()
    {
        return
            "public class " + PanelName + PanelScriptInheritance + "\r\n" +
            "{\r\n" +

            k_Tab + "void Start()\r\n" +
            k_Tab + "{\r\n" +
            "\r\n" +
            k_Tab + "}\r\n" +

             "\r\n" +

            k_Tab + "public void RegisterComponent()\r\n" +
            k_Tab + "{\r\n" +
            "\r\n" +
            k_Tab + "}\r\n" +
            k_Tab + "public void UnRegisterComponent()\r\n" +
            k_Tab + "{\r\n" +
            "\r\n" +
            k_Tab + "}\r\n" +

            "\r\n" +

            k_Tab + "public void RegisterCommand()\r\n" +
            k_Tab + "{\r\n" +
            "\r\n" +
            k_Tab + "}\r\n" +
            k_Tab + "public void RemoveCommand()\r\n" +
            k_Tab + "{\r\n" +
            "\r\n" +
            k_Tab + "}\r\n" +

            "\r\n" +

            k_Tab + "public void RegisterMediator()\r\n" +
            k_Tab + "{\r\n" +
            k_Tab + k_Tab + "ApplicationFacade.Instance.RegisterMediator(new " + MediatorName + "(" + MediatorName + ".NAME, this));\r\n" +
            k_Tab + "}\r\n" +
            k_Tab + "public void RemoveMediator()\r\n" +
            k_Tab + "{\r\n" +
            k_Tab + k_Tab + "ApplicationFacade.Instance.RemoveMediator(" + MediatorName + ".NAME);\r\n" +
            k_Tab + "}\r\n" +
            "}\r\n";
    }
    public string CreatMediatorString()
    {
        return
           "public class " + MediatorName + MediatorInheritance + "\r\n" +
           "{\r\n" +
           k_Tab + "public new static string NAME = " + "nameof(" + MediatorName + ");" + "\r\n" +

           k_Tab + "public " + MediatorName + "(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)\r\n" +
           k_Tab + "{\r\n" +
           k_Tab + "}\r\n" +

           "\r\n" +
           k_Tab + "public " + PanelName + " " + "GetPanel" + "\r\n" +
           k_Tab + "{\r\n" +
           k_Tab + k_Tab + "get" + "\r\n" +
           k_Tab + k_Tab + "{" + "\r\n" +
           k_Tab + k_Tab + k_Tab + "return ViewComponent as " + PanelName + ";" + "\r\n" +
           k_Tab + k_Tab + "}" + "\r\n" +
           k_Tab + "}\r\n" +
           "\r\n" +

           k_Tab + "public override string[] ListNotificationInterests()\r\n" +
           k_Tab + "{\r\n" +
           k_Tab + k_Tab + "List<string> listNotificationInterests = new List<string>();" + "\r\n" +
           k_Tab + k_Tab + "return listNotificationInterests.ToArray();" + "\r\n" +
           k_Tab + "}\r\n" +

           "\r\n" +

           k_Tab + "public override void HandleNotification(INotification notification)\r\n" +
           k_Tab + "{\r\n" +
           "\r\n" +
           k_Tab + "}\r\n" +

           "\r\n" +

            k_Tab + "public override void OnRegister()\r\n" +
           k_Tab + "{\r\n" +
           "\r\n" +
           k_Tab + "}\r\n" +

           "\r\n" +

           k_Tab + "public override void OnRemove()\r\n" +
           k_Tab + "{\r\n" +
           "\r\n" +
           k_Tab + "}\r\n" +
           "}\r\n";
    }
    public string CreateLoadOrOpenCommandString()
    {
        return
           "public class " + CommandFileNamePrefix_Open + CommandName + " : SimpleCommand" + "\r\n" +
           "{\r\n" +

           k_Tab + " public override void Execute(INotification notification)\r\n" +
           k_Tab + "{\r\n" +
           "\r\n" +
           k_Tab + "}\r\n" +

           "}\r\n";
    }
    public string CreateUnLoadOrOpenCommandString()
    {
        return
           "public class " + CommandFileNamePrefix_Close + CommandName + " : SimpleCommand" + "\r\n" +
           "{\r\n" +

           k_Tab + " public override void Execute(INotification notification)\r\n" +
           k_Tab + "{\r\n" +
           "\r\n" +
           k_Tab + "}\r\n" +

           "}\r\n";
    }
    public string CreateCommandString()
    {
        return
           "public class " + CommandName + " : SimpleCommand" + "\r\n" +
           "{\r\n" +

           k_Tab + " public override void Execute(INotification notification)\r\n" +
           k_Tab + "{\r\n" +
           "\r\n" +
           k_Tab + "}\r\n" +

           "}\r\n";
    }

    #endregion


    #region 内部数据
    private string PanelName { get; set; }
    private string MediatorName { get; set; }
    private string CommandName { get; set; }
    #endregion

    #region 创建模块相关
    [Title("创建对应模块的名称", "", TitleAlignments.Centered)]
    [TabGroup("CreateScriptTemplate", "Module")]
    public string ModuleScriptName;

    [ShowIf("$CheckModuleName")]
    [ResponsiveButtonGroup("CreateScriptTemplate/Module/CreatScript")]
    [Button("创建模块相关脚本", ButtonSizes.Gigantic)]
    public void CreatModule()
    {
        PanelName = ModuleScriptName;
        MediatorName = ModuleScriptName + "Mediator";
        CommandName = ModuleScriptName + "Command";

        CreateScript(PanelName, AdditionalNamespacesToString() + CreatePanelString());
        CreateScript(MediatorName, AdditionalNamespacesToString() + CreatMediatorString());
        CreateScript(CommandFileNamePrefix_Open + PanelName + CommandlFileNameSuffix, AdditionalNamespacesToString() + CreateLoadOrOpenCommandString());
        CreateScript(CommandFileNamePrefix_Close + PanelName + CommandlFileNameSuffix, AdditionalNamespacesToString() + CreateUnLoadOrOpenCommandString());
        AssetDatabase.Refresh();
        Debug.Log("生成代码完毕");
    }

    public bool CheckModuleName()
    {
        if (string.IsNullOrEmpty(ModuleScriptName) || string.IsNullOrEmpty(FilePath))
        {
            return false;
        }
        bool isValid = CodeGenerator.IsValidLanguageIndependentIdentifier(ModuleScriptName);
        return isValid;
    }
    #endregion


    #region 创建Mediator
    [TabGroup("CreateScriptTemplate", "Mediator")]
    [Title("创建对应Mediator的名称", "", TitleAlignments.Centered)]
    public string MediatorScriptName;
    [TabGroup("CreateScriptTemplate", "Mediator")]
    [Title("含有Panel的名称", "", TitleAlignments.Centered)]
    public string TargetPanelScriptName;

    [ShowIf("$CheckMediatorName")]
    [Button("创建Mediator脚本", ButtonSizes.Gigantic)]
    [ResponsiveButtonGroup("CreateScriptTemplate/Mediator/CreatMediator")]
    public void CreatMediator()
    {
        PanelName = TargetPanelScriptName;
        MediatorName = MediatorScriptName;

        CreateScript(MediatorName, AdditionalNamespacesToString() + CreatMediatorString());
        AssetDatabase.Refresh();
        Debug.Log("生成代码完毕");
    }

    public bool CheckMediatorName()
    {
        if (string.IsNullOrEmpty(MediatorScriptName) || string.IsNullOrEmpty(FilePath))
        {
            return false;
        }
        bool isValid = CodeGenerator.IsValidLanguageIndependentIdentifier(MediatorScriptName);
        return isValid;
    }
    #endregion

    #region 创建Command
    [TabGroup("CreateScriptTemplate", "Command")]
    [Title("创建对应Command的名称", "", TitleAlignments.Centered)]
    public string CommandScriptName;

    public static string PanelScriptInheritance1 => PanelScriptInheritance;

    [ShowIf("$CheckCommandName")]
    [Button("创建Command脚本", ButtonSizes.Gigantic)]
    [ResponsiveButtonGroup("CreateScriptTemplate/Command/CreatCommand")]
    public void CreatCommand()
    {
        CommandName = CommandScriptName;

        CreateScript(CommandName, AdditionalNamespacesToString() + CreateCommandString());
        AssetDatabase.Refresh();
        Debug.Log("生成代码完毕");
    }

    public bool CheckCommandName()
    {
        if (string.IsNullOrEmpty(CommandScriptName) || string.IsNullOrEmpty(FilePath))
        {
            return false;
        }
        bool isValid = CodeGenerator.IsValidLanguageIndependentIdentifier(CommandScriptName);
        return isValid;
    }
    #endregion
}
