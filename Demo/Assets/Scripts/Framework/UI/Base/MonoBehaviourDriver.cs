using PureMVC.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonoBehaviourDriver : MonoBehaviour
{
    private List<UnityMediator> unityMediators = new List<UnityMediator>();
    public Action OnEnable;
    public Action OnDisable;

    public string panelName;
    private void Awake()
    {
        if (string.IsNullOrEmpty(panelName))
        {
            Debug.LogError($"{panelName} 为 null 请检查");
            return;
        }
        //从容器中获取工厂
        var behaviour = UIManager.Instance.GetBehaviour(panelName);

        var mediatorFactorys = behaviour.ListUnityMediatorInterests();
        for (int index = 0; index < mediatorFactorys.Count; index++)
        {
            var factory = mediatorFactorys[index];
            var mediator = factory();

            //数据、事件等相关属性注册
            mediator.ViewComponent = gameObject;

            BathRegisterAction(mediator);

            unityMediators.Add(mediator);
        }

        
        foreach (var mediator in unityMediators)
        {
            ApplicationFacade.Instance.RegisterMediator(mediator);
        }
    }


    private void Start()
    {
        foreach (var mediator in unityMediators)
        {
            mediator.Start();
        }
    }

    private void OnDestroy()
    {
        //注销时必须以相反的顺序注销
        unityMediators.Reverse();

        foreach (var mediator in unityMediators)
        {
            BathUnRegisterAction(mediator);

            if (mediator is IOnDestory onDestory)
            {
                onDestory.OnDestory();
            }
        }
    }

    private void BathRegisterAction(IMediator mediator)
    {
        if (mediator is IOnEnable onEnable)
        {
            OnEnable += onEnable.OnEnable;
        }

        if (mediator is IUpdate update)
        {
            GameLoop.Instance.OnUpdate += update.Update;
        }

        if (mediator is IOnDisable onDisable)
        {
            OnDisable += onDisable.OnDisable;
        }
    }

    private void BathUnRegisterAction(IMediator mediator)
    {
        if (mediator is IOnDisable onDisable)
        {
            OnEnable -= onDisable.OnDisable;
        }

        if (mediator is IUpdate update)
        {
            GameLoop.Instance.OnUpdate -= update.Update;
        }

        if (mediator is IOnEnable onEnable)
        {
            OnEnable -= onEnable.OnEnable;
        }
    }

}
