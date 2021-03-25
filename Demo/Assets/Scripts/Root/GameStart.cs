using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : SingletonMonoBehaviour<GameStart>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        ApplicationFacade.Instance.StartUpHandle();
    }
    void Start()
    {
        ApplicationFacade.Instance.SendNotification(nameof(StartUpCommand), gameObject);

        var rootMediator = new RootMediator(nameof(RootMediator), this);
        ApplicationFacade.Instance.RegisterMediator(rootMediator);
        var start = rootMediator as IStart;
        start?.Start();

        var update = rootMediator as IUpdate;
        if (update!=null)
        {
            GameLoop.Instance.OnUpdate += update.Update;
        }
    }
}
