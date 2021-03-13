using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMenuPanelCommand
{
    public void Excute()
    {
        var serverData = new ServerData();
        var needData = serverData.GetNeedData();
        //TODO:正常情况下不应该直接传入基本类型，应该传入对应的自定义类，为了示例简单暂且代替
        var menuPanel = new MenuPanel(needData);
        menuPanel.UpdateMenu();
    }
}
