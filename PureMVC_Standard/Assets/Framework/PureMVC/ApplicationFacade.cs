using PureMVC.Patterns.Facade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationFacade : Facade
{
    private static object syncRoot = new Object();

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
    public void StartUp()
    {
        
    }

}
