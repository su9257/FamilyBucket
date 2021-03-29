using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLoginCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        UIManager.Instance.LoadAsyncAndInject("LoginPanel", () => new LoginBehaviourRoot());
    }
}
