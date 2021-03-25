using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMediator : UnityMediator
{
    public RootMediator(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
    {
       
    }

    public override void Start()
    {
        var panelLauncherFactory = PanelLauncher.PanelLauncherFactory;
        foreach (var keyValuePair in panelLauncherFactory)
        {
            ApplicationFacade.Instance.RegisterCommand(keyValuePair.Key, keyValuePair.Value);
        }
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("按键1");
            SendNotification(nameof(OpenLoginCommand));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("按键2");
            SendNotification(nameof(CloseLoginCommand));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("按键3");
            SendNotification(nameof(OpenMainCityCommand));
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("按键4");
            SendNotification(nameof(CloseMainCityCommand));
        }
    }
}
