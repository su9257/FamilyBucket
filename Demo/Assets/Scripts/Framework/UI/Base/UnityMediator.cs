using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityMediator : Mediator, IStart, IOnEnable, IUpdate, IOnDisable, IOnDestory
{
    /// <summary>
    /// 用于区别 IMediator 实例的名称
    /// </summary>
    public static new string NAME = "Mediator";
    public UnityMediator(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
    {
        NAME = mediatorName;
    }

    public GameObject GetPanelGameObject
    {
        get
        {
            return ViewComponent as GameObject;
        }
    }

    public sealed override void OnRegister()
    {

    }

    public sealed override void OnRemove()
    {
        OnDestory();
    }

    public virtual void Start()
    {
        Debug.Log($"{MediatorName}:Start");
    }

    public virtual void Update()
    {
        Debug.Log($"{MediatorName}:Update");
    }

    public virtual void OnDestory()
    {
        Debug.Log($"{MediatorName}:OnDestroy");
    }

    public virtual void OnEnable()
    {

    }

    public virtual void OnDisable()
    {

    }

    public T LoadAssetAynsc<T>(string assetName) where T : UnityEngine.Object
    {
        return default;
    }
}
