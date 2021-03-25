using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReadOnly : MonoBehaviour
{
    public readonly List<string> tempList = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        tempList.Add("1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
