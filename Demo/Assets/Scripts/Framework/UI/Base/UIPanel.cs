using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasScaler))]
[RequireComponent(typeof(GraphicRaycaster))]
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(MonoBehaviourDriver))]
public class UIPanel : MonoBehaviour
{
    [ReadOnly]
    [LabelText("面板名称")]
    public string UIPanelName;

    private const string FoldoutGroupTitle = "参数相关";
    [FoldoutGroup(FoldoutGroupTitle, expanded: true)]
    public Canvas canvas;
    [FoldoutGroup(FoldoutGroupTitle, expanded: true)]
    public int OrderInLayer
    {
        get
        {
            return canvas.sortingOrder;
        }
    }

    [InfoBox("<size=15>此层级决定面板的排序叠加情况</size>")]
    [LabelText("面板层级")]
    [ValueDropdown("panleLayerList", DropdownTitle = "选择此面板对应的层级")]
    public UIManager.PanleLayer panleLayer;

    [PropertySpace(20)]
    [InfoBox("<size=15>此界面需要显示的货币栏个数及对应的种类</size>")]
    [LabelText("货币栏内容")]
    [ValueDropdown("panleCurrencyList", DropdownTitle = "选择此面板需要显示的货币种类")]
    public List<UIManager.Currency> displayCurrencyList = new List<UIManager.Currency>();

    [PropertySpace(20)]
    [InfoBox("<size=15>自动添加灰度底框？</size>")]
    public bool isAutoGrayMask;

    [PropertySpace(20)]
    [InfoBox("<size=15>自动隐藏底层级非常驻面板？</size>")]
    public bool isAutoHideChildrenPanel;

    [PropertySpace(20)]
    [InfoBox("<size=15>永远不会被隐藏？</size>")]
    public bool isAlwaysStayOpen;

    [PropertySpace(20)]
    [InfoBox("<size=15>自动执行注册事件？</size>")]
    [SerializeField]
    private bool isAutoRegister = true;

    private IMonoBehaviour monoBehaviour { get; set; }

    private MonoBehaviourDriver behaviourDriver;
    
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        behaviourDriver = GetComponent<MonoBehaviourDriver>();
        if (behaviourDriver==null)
        {
            Debug.LogError("behaviourDriver is null, please cheack it !!!");
        }
    }

    public virtual void OpenUIPanel()
    {
        //防止反复触发
        if (canvas.enabled)
        {
            return;
        }
        canvas.enabled = true;
        behaviourDriver.OnEnable?.Invoke();
    }
    public virtual void CloseUIPanel()
    {
        //防止反复触发
        if (!canvas.enabled)
        {
            return;
        }
        canvas.enabled = false;
        behaviourDriver.OnDisable?.Invoke();
    }


    private IEnumerable panleLayerList = new ValueDropdownList<UIManager.PanleLayer>()
    {
      { "主页", UIManager.PanleLayer.LayerIndex0 },
      { "状态栏", UIManager.PanleLayer.LayerIndex1 },
      { "跑马灯", UIManager.PanleLayer.LayerIndex2 },
      { "普通飘字Tips", UIManager.PanleLayer.LayerIndex3 },
      { "活动界面", UIManager.PanleLayer.LayerIndex4 },
      { "新手引导", UIManager.PanleLayer.LayerIndex5 },
      { "过场界面", UIManager.PanleLayer.LayerIndex6 },
      { "强制弹出提示", UIManager.PanleLayer.LayerIndex7 },
    };

    private IEnumerable panleCurrencyList = new ValueDropdownList<UIManager.Currency>()
    {
      { "货币0", UIManager.Currency.Number0 },
      { "货币1", UIManager.Currency.Number1 },
      { "货币2", UIManager.Currency.Number2 },
      { "货币3", UIManager.Currency.Number3 },
      { "货币4", UIManager.Currency.Number4 },
      { "货币5", UIManager.Currency.Number5 },
      { "货币6", UIManager.Currency.Number6 },
      { "货币7", UIManager.Currency.Number7 },
    };

}
