using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMediator_0 : UnityMediator
{
    public LoginMediator_0(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
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
        Debug.Log($"{nameof(LoginMediator_0)}---OnDestory");
    }

    public override void OnDisable()
    {
        Debug.Log($"{nameof(LoginMediator_0)}---OnDisable");
    }

    public override void OnEnable()
    {
        Debug.Log($"{nameof(LoginMediator_0)}---OnEnable");
    }

    public override void Start()
    {
        Debug.Log($"{nameof(LoginMediator_0)}---Start");
    }

    public override void Update()
    {
        Debug.Log($"<color=#FFD61A>{nameof(LoginMediator_0)}---Update</color>");
    }
}
