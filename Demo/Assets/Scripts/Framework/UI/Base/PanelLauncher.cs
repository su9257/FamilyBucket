using PureMVC.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLauncher
{
    public static List<KeyValuePair<string, Func<ICommand>>> PanelLauncherFactory = new List<KeyValuePair<string, Func<ICommand>>>()
    {
        //Login界面
        new KeyValuePair<string, Func<ICommand>>(nameof(OpenLoginCommand),()=> new OpenLoginCommand()),
        new KeyValuePair<string, Func<ICommand>>(nameof(CloseLoginCommand),()=> new CloseLoginCommand()),
        //MainCity界面
        new KeyValuePair<string, Func<ICommand>>(nameof(OpenMainCityCommand),()=> new OpenMainCityCommand()),
        new KeyValuePair<string, Func<ICommand>>(nameof(CloseMainCityCommand),()=> new CloseMainCityCommand()),
    };

}
