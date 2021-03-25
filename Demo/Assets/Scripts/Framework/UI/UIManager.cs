using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Collections.Concurrent;

public class UIManager : SingletonMonoBehaviour<UIManager>
{

    public enum PanleLayer
    {
        LayerIndex0, LayerIndex1, LayerIndex2, LayerIndex3, LayerIndex4, LayerIndex5, LayerIndex6, LayerIndex7
    }

    public enum Currency
    {
        Number0, Number1, Number2, Number3, Number4, Number5, Number6, Number7, Number8, Number9, Number10
    }

    protected override void Awake()
    {
        base.Awake();
        Initialization();
    }
    void Start() { }

    private Camera uiCamera;
    public Camera UICamera
    {
        get { return uiCamera; }
    }

    private int order;

    private Transform uiRoot;
    public Transform UIRoot
    {
        get { return uiRoot; }
    }

    /// <summary>
    /// 现有所有Panel
    /// </summary>
    private ConcurrentDictionary<string, UIPanel> panelContainer = new ConcurrentDictionary<string, UIPanel>();
    /// <summary>
    /// 现有所有Panel
    /// 用工厂的原因是确保从容器中每次获取都是新的
    /// </summary>
    private ConcurrentDictionary<string, Func<IMonoBehaviour>> behaviourContainer = new ConcurrentDictionary<string, Func<IMonoBehaviour>>();

    /// <summary>
    /// 每次都会获取一个新的IMonoBehaviour实例
    /// </summary>
    /// <param name="panelName"></param>
    /// <returns></returns>
    public IMonoBehaviour GetBehaviour(string panelName)
    {
        behaviourContainer.TryGetValue(panelName, out Func<IMonoBehaviour> factory);
        if (factory == null)
        {
            Debug.LogError($"{panelName} 对应的 IMonoBehaviour 为 null");
        }
        return factory != null ? factory() : default;
    }
    /// <summary>
    /// 临时用于排序
    /// </summary>
    private List<UIPanel> uIPanels = new List<UIPanel>();

    private void Initialization()
    {
        //加载UIRoot
        uiRoot = Instantiate(Resources.Load<GameObject>("Prefabs/UIRoot")).transform;
        uiRoot.name = "UIRoot";

        uiCamera = uiRoot.transform.Find("UICamera").GetComponent<Camera>();
    }
    public void LoadAsyncAndInject(string key, Func<IMonoBehaviour> factory)
    {
        if (panelContainer.ContainsKey(key))
        {
            Debug.LogWarning($"已经含有对应面板：{key}，不能重复加载");
            return;
        }
        //添加到Behaviour容器
        if (!behaviourContainer.ContainsKey(key))
        {
            behaviourContainer[key] = factory;
        }
        LoadAsync(key, SetPanelStateAndInject);
    }

    private void SetPanelStateAndInject(GameObject panelObj)
    {
        UIPanel uIPanel = panelObj.GetComponent<UIPanel>();

        uIPanel.name = uIPanel.name.Replace("(Clone)", "");
        panelContainer[uIPanel.name] = uIPanel;
        uIPanel.transform.SetParent(UIRoot, false);
        //设置组件上需要的数据
        SetCanvasState(uIPanel);
        //关联扩展
        SetPanelExtension(uIPanel);
        //排序
        PanelSortAndDisplay();
    }




    public void UnLoadOrCloseUIPanel(string panelName)
    {
        if (!panelContainer.ContainsKey(panelName))
        {
            Debug.LogWarning($"没有找到需要卸载或者销毁的Panel：{panelName} ，请检查");
            return;
        }
        //bool isSuccessful = AddressableManager.UnLoadAssetOfGameObject(moduleName);
        bool isSuccessful = true;
        if (isSuccessful)
        {
            panelContainer.TryRemove(panelName, out UIPanel uIPanel);
            uIPanel.CloseUIPanel();
            //临时代替
            Destroy(uIPanel.gameObject);

            PanelSortAndDisplay();
        }
        else
        {
            Debug.LogWarning($"卸载失败：{panelName}");
        }
    }
    /// <summary>
    /// 初始化组件状态相关
    /// </summary>
    /// <param name="uIPanel"></param>
    /// <param name="uIParameters"></param>
    private void SetCanvasState(UIPanel uIPanel)
    {
        uIPanel.canvas.renderMode = RenderMode.ScreenSpaceCamera;
        uIPanel.canvas.pixelPerfect = true;
        uIPanel.canvas.worldCamera = UICamera;
        uIPanel.canvas.sortingLayerID = (int)uIPanel.panleLayer;

        uIPanel.canvas.sortingOrder = order;
        ++order;
    }
    /// <summary>
    /// 设置UIPanel所关联的扩展，例如MASK 属性栏
    /// </summary>
    private void SetPanelExtension(UIPanel uIPanel)
    {
        //判断是否添加Mask
        //if (uIPanel.isAutoGrayMask)
        //{
        //    UIMaskManager.Instance.CreateMask(uIPanel.transform, UIMaskManager.UIMaskType.Dark, uIPanel.CloseUIPanel);
        //}
    }

    private void PanelSortAndDisplay()
    {
        uIPanels.Clear();
        uIPanels = panelContainer.Select(a => a.Value).ToList();
        if (uIPanels.Count <= 0)
        {
            return;
        }
        //根据panleLayer由低到高排序，如果panleLayer相等根据orderInLayer排序
        uIPanels.Sort((a, b) =>
        {
            return a.panleLayer != b.panleLayer ? a.panleLayer.CompareTo(b.panleLayer) : a.OrderInLayer.CompareTo(b.OrderInLayer);
        });

        //方便在调试模式时观察Hierarchy的变化
        for (int i = 0; i < uIPanels.Count; i++)
        {
            uIPanels[i].transform.SetAsLastSibling();
        }

        //找到第一个isAutoHideChildrenPanel
        int? index = null;
        for (int i = uIPanels.Count - 1; i >= 0; i--)
        {
            if (uIPanels[i].isAutoHideChildrenPanel == true)
            {
                index = i;
                break;
            }
        }

        //倒叙找到第一个需要显示属性状态栏目的
        for (int i = uIPanels.Count - 1; i >= 0; i--)
        {
            if (uIPanels[i].displayCurrencyList.Count > 0)
            {
                Debug.Log("发送关注货币栏目消息");
                break;
            }
        }

        //高于AutoHideChildrenPanel全部开启，低于AutoHideChildrenPanel的除了常驻全部关闭
        for (int i = 0; i < uIPanels.Count; i++)
        {
            if (i < (index) && !uIPanels[i].isAlwaysStayOpen)
            {
                uIPanels[i].CloseUIPanel();
            }
            else
            {
                uIPanels[i].OpenUIPanel();
            }
        }

    }


    #region 临时代替
    private void LoadAsync(string panelName, Action<GameObject> callback)
    {
        StartCoroutine(ResourcesLoadAsync(panelName, callback));
    }

    IEnumerator ResourcesLoadAsync(string panelName, Action<GameObject> callback)
    {
        var resourceRequest = Resources.LoadAsync<GameObject>(panelName);
        yield return resourceRequest;
        var panelObj = resourceRequest.asset as GameObject;

        if (panelObj == null)
        {
            Debug.LogError("panelObj为null请检查");
        }

        callback?.Invoke(Instantiate(panelObj));
    }
    #endregion

}