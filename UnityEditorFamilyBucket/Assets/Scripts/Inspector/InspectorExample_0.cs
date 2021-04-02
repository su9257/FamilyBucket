using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorExample_0 : MonoBehaviour
{
    [SerializeField]
    private string privateFieldContent = "菜鸟海澜";

    public int id = 9257;
    public string description = "这是一条描述";

    public int sliderIntValue;
    public float sliderFloatValue;
    public float minValue = 0;
    public float maxValue = 100;

    public float progressBarValue;
    public string warningContent = "这是一条警告内容";

    public string item_0 = "条目0";
    public string item_1 = "条目1";
    public string item_2 = "条目2";

    public string readOnlyItem_0 = "只读条目_0";
    public string readOnlyItem_1 = "只读条目_1";
    public string readOnlyItem_2 = "只读条目_2";
}
