using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpCommand : MacroCommand
{
    protected override void InitializeMacroCommand()
    {
        AddSubCommand(() => new RunAssetManagerCommand());
        AddSubCommand(() => new RunUIManagerCommand());
        AddSubCommand(() => new RunServerManagerCommand());
        AddSubCommand(() => new RunGameLoopManagerCommand());
    }
}

public class RunUIManagerCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var gameStartObj = notification.Body as GameObject;
        if (gameStartObj)
        {
            gameStartObj.AddComponent<UIManager>();
        }
        Debug.Log($"{nameof(RunUIManagerCommand)}:加载成功");
    }
}

public class RunAssetManagerCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        Debug.Log($"{nameof(RunAssetManagerCommand)}:加载成功");
    }
}

public class RunServerManagerCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        Debug.Log($"{nameof(RunServerManagerCommand)}:加载成功");
    }
}

public class RunGameLoopManagerCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var gameLoopObject = notification.Body as GameObject;
        if (gameLoopObject != null)
        {
            gameLoopObject.AddComponent<GameLoop>();
        }
        Debug.Log($"{nameof(RunGameLoopManagerCommand)}:加载成功");
    }
}

