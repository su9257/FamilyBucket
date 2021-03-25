using System;
using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using PureMVC.Patterns.Command;
using UnityEngine;

public class TestPanel_0_Mediator_0 : UnityMediator
{
    public TestPanel_0_Mediator_0(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
    {
    }


    public override string[] ListNotificationInterests()
    {
        return default;
    }

    public override void HandleNotification(INotification notification)
    {

    }

    public override void Start()
    {
        Dictionary<string, string> aaaDictionary = new Dictionary<string, string>();
    }

    public override void Update()
    {
        var aa = new List<KeyValuePair<string, Func<ICommand>>>
        {
            new KeyValuePair<string, Func<ICommand>>("123", () => new TestCommand())
        };
    }

    public override void OnDestory()
    {

    }
}


public class TestCommand : SimpleCommand
{

}