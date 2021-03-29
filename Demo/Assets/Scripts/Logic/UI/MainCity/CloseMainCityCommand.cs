﻿using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMainCityCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        UIManager.Instance.UnLoadOrCloseUIPanel("MainCityPanel");
    }
}