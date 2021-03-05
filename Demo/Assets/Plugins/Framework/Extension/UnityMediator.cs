using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityMediator : Mediator, IMonoBehaviour
{
    /// <summary>
    /// 用于区别 IMediator 实例的名称
    /// </summary>
    public static new string NAME = "Mediator";
    public UnityMediator(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
    {
        NAME = mediatorName;
    }

    public sealed override void OnRegister()
    {
        base.OnRegister();
    }

    public void Awake()
    {
        Debug.Log($"{MediatorName}:Awake");
    }


    public virtual void Start()
    {
        Debug.Log($"{MediatorName}:Start");
    }

    public virtual void Update()
    {
        Debug.Log($"{MediatorName}:Update");
    }

    public virtual void OnDestroy()
    {

    }
}
