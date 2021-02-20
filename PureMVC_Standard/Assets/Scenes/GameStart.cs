using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ApplicationFacade.Instance.StartUp();
        ApplicationFacade.Instance.SendNotification(ApplicationConstants.GameStart);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

        }
    }

    public IList<Func<IMediator>> mediatorFactory = new List<Func<IMediator>>();

    private void InitializePanel()
    {
        mediatorFactory.Add(() => new Mediator(nameof(Mediator), this));

        for (int i = 0; i < mediatorFactory.Count; i++)
        {
            var tempMediator = mediatorFactory[i]();
            ApplicationFacade.Instance.RegisterMediator(tempMediator);
        }
    }
}
