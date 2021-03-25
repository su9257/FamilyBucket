using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using UnityEngine;

public class TestLifeCycle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"{nameof(TestLifeCycle)}:Start");
    }

    private void LateUpdate()
    {

    }

    private void FixedUpdate()
    {

    }

    private void Awake()
    {
        
        //字典维护 Key：PanelName 和 Valuw：IMonoBehaviour 的关系
        //采用绑定机制，在Awake中去容器查询对应的IMonoBehaviour
        Debug.Log($"{nameof(TestLifeCycle)}:Awake");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Log()
    {
        Debug.Log("Log");
    }
}

//public class UIManager
//{
//    public static void LoadAndInjectMono(string prefabName,IMonoBehaviour vmMonoBehaviour)
//    {

//    }
//}
     
