using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMediator_1 : UnityMediator
{
    public LoginMediator_1(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
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
        Debug.Log($"{nameof(LoginMediator_1)}---OnDestory");
    }

    public override void OnDisable()
    {
        Debug.Log($"{nameof(LoginMediator_1)}---OnDisable");
    }

    public override void OnEnable()
    {
        Debug.Log($"{nameof(LoginMediator_1)}---OnEnable");
    }

    public override void Start()
    {
        Debug.Log($"{nameof(LoginMediator_1)}---Start");
    }

    public override void Update()
    {
        Debug.Log($"<color=#27DED4>{nameof(LoginMediator_1)}---Update</color>");
    }
}
