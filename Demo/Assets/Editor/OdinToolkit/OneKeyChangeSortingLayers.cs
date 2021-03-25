//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using System;
//using Sirenix.OdinInspector;

//public class OneKeyChangeSortingLayers : SerializedScriptableObject
//{
//#pragma warning disable CS0414
//    private bool initialized = false;
//#pragma warning restore CS0414  

//    [ShowIf("initialized")]
//    [ReadOnly]
//    [DictionaryDrawerSettings(KeyLabel = "优先级依次升高", ValueLabel = "对应层级名称",DisplayMode =  DictionaryDisplayOptions.OneLine)]
//    public Dictionary<int, string> panelLayerDic = new Dictionary<int, string>();

//    [ShowIf("initialized")]
//    [Button("一键更改SortLayer", ButtonSizes.Gigantic)]
//    public void OneKeyChange()
//    {
//        ChangeSortingLayer();
//    }
//    [ShowIf("@initialized==false")]
//    [Button("初始化需要设置的SortLayer", ButtonSizes.Gigantic)]
//    public void Initialized()
//    {
//        panelLayerDic.Clear();

//        foreach (int v in Enum.GetValues(typeof(global::UIManager.PanleLayer)))
//        {
//            string name = Enum.GetName(typeof(global::UIManager.PanleLayer), v);
//            panelLayerDic[v] = name;
//        }
//        initialized = true;
//    }


//    public void ChangeSortingLayer()
//    {
//        // 先遍历枚举拿到枚举的字符串
//        List<string> panelLayerList = new List<string>();
//        foreach (int v in Enum.GetValues(typeof(global::UIManager.PanleLayer)))
//        {
//            panelLayerList.Add(Enum.GetName(typeof(global::UIManager.PanleLayer), v));
//        }

//        // 清除数据
//        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAssetAtPath("ProjectSettings/TagManager.asset", typeof(UnityEngine.Object)));
//        if (tagManager == null)
//        {
//            Debug.LogError("TagManager.asset初始化失败，请检查");
//            return;
//        }
//        SerializedProperty property = tagManager.GetIterator();
//        while (property.NextVisible(true))
//        {
//            if (property.name != "m_SortingLayers")
//            {
//                continue;
//            }
//            // 先删除所有
//            property.ClearArray();

//            //填充新的数据
//            foreach (var panelLayer in panelLayerList)
//            {
//                property.InsertArrayElementAtIndex(property.arraySize);
//                SerializedProperty dataPoint = property.GetArrayElementAtIndex(property.arraySize - 1);

//                while (dataPoint.NextVisible(true))
//                {
//                    if (dataPoint.name == "name")
//                    {
//                        dataPoint.stringValue = panelLayer;
//                    }
//                    else if (dataPoint.name == "uniqueID")
//                    {
//                        Debug.Log($"设置的数值为：{(int)Enum.Parse(typeof(global::UIManager.PanleLayer), panelLayer)}");
//                        dataPoint.intValue = (int)Enum.Parse(typeof(global::UIManager.PanleLayer), panelLayer);
//                    }
//                }
//            }
//        }
//        tagManager.ApplyModifiedProperties();
//        tagManager.Update();
//        AssetDatabase.SaveAssets();
//    }

//    public bool IsHaveSortingLayer(string sortingLayer)
//    {
//        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/Tagmanager.asset")[0]);
//        if (tagManager == null)
//        {
//            Debug.LogError("TagManager.asset初始化失败，请检查");
//            return true;
//        }
//        SerializedProperty it = tagManager.GetIterator();
//        while (it.NextVisible(true))
//        {
//            if (it.name != "m_SortingLayers")
//            {
//                continue;
//            }
//            for (int i = 0; i < it.arraySize; i++)
//            {
//                SerializedProperty dataPoint = it.GetArrayElementAtIndex(i);
//                while (dataPoint.NextVisible(true))
//                {
//                    if (dataPoint.name != "name")
//                    {
//                        continue;
//                    }
//                    if (dataPoint.stringValue == sortingLayer)
//                    {
//                        return true;
//                    }
//                }
//            }
//        }
//        return false;
//    }
//}
