using SheetData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class TestMono : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //JobRow jobRow = new JobRow();

        //var type = typeof(JobRow);
        //var fileds = type.GetFields(BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic);
        //for (int i = 0; i < fileds.Length; i++)
        //{
        //    Debug.Log(fileds[i].Name);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //GameObject tempObj =  Instantiate(Resources.Load<GameObject>("TestPanel_1"));
            // tempObj.AddComponent<TestLifeCycle>().Log();
            // Debug.Log("*******");
            var testAwake = gameObject.AddComponent<TestAwake>();
            Debug.Log(new string('*', 20));
            testAwake.TestInvoke();
        }
    }
}
