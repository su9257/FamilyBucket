using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Core;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVC.Patterns.Command;
using PureMVC.Patterns.Facade;
using PureMVC.Patterns.Mediator;
using PureMVC.Patterns.Observer;
using PureMVC.Patterns.Proxy;


public class ApplicationFacade : Facade
{
    private static object syncRoot = new System.Object();

    public static ApplicationFacade Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new ApplicationFacade();
                    }
                }
            }
            return instance as ApplicationFacade;
        }
    }
    public Action OnUpdate;
    public Action OnFixedUpdate;
    public Action OnLateUpdate;
    public void StartUpHandle()
    {
        Debug.Log("<color=#00FFFD><size=15>PureMVC初始化</size></color>");
    }

}