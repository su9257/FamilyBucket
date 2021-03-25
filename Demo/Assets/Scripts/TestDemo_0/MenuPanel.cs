public class MenuPanel_0
{
    public MenuPanel_0()
    {
        var menuData = GetMenuData();
        SetMenuDataAndUpdate(menuData);
    }

    public string GetMenuData()
    {
        // do something...
        return default;
    }

    public void SetMenuDataAndUpdate(string temp)
    {
        // do something...
    }
}

public class ServerData
{
    public string GetNeedData()
    {
        /*
         * 请求 函数
         * 验证 函数
         * 解析 函数
         * 整合 函数
         * 筛选 函数
         */
        return default;
    }

}

public class MenuPanel
{
    private string m_NeedData;
    public MenuPanel(string needData)
    {
        m_NeedData = needData;
    }

    public void UpdateMenu()
    {
        // do something...
    }
}

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

