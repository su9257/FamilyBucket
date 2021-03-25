using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPanelMediator : UnityMediator
{
    public TestPanelMediator(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
    {
    }

    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
    }

    public override string[] ListNotificationInterests()
    {
        return base.ListNotificationInterests();
    }

    public override void OnDestory()
    {
        base.OnDestory();
    }


    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}
