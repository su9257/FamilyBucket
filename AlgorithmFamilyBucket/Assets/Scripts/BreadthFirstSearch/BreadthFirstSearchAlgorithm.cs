using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BreadthFirstSearchAlgorithm : MonoBehaviour
{
    private static Dictionary<string, string[]> graph = new Dictionary<string, string[]>();
    
    void Start()
    {
        graph.Add("You", new[] { "A0", "A1", "A2" });
        graph.Add("A1", new[] { "A3", "A4" });
        graph.Add("A0", new[] { "A4" });
        graph.Add("A2", new[] { "A5", "A6" });
        graph.Add("A3", Array.Empty<string>());
        graph.Add("A4", Array.Empty<string>());
        graph.Add("A5", Array.Empty<string>());
        graph.Add("A6", new[] { "A5", "海澜" });
        Search("You");
    }

    private static bool Search(string name)
    {
        var searchQueue = new Queue<string>(graph[name]);                         //需要搜索的队列
        var searched = new List<string>();                                                            //已经搜索过的人物列表，防止循环引用的搜索

        while (searchQueue.Any())                                                                       //如果列表不为空就一直搜索
        {
            var person = searchQueue.Dequeue();

            if (!searched.Contains(person))
            {
                if (PersonIsHaiLan(person))
                {
                    Debug.Log($"{person} 是需要找到的人");
                    return true;
                }
                else
                {
                     var newSearchQueue = searchQueue.Concat(graph[person]);  //将此人的所有直接联系人（一级）添加到待搜索的列表
                    searchQueue = new Queue<string>(newSearchQueue);

                    searched.Add(person);                                                               //已经搜索的人添加到列表中，防止循环引用搜索        
                }
            }
        }
        return false;
    }

    private static bool PersonIsHaiLan(string name)
    {
        return name.Equals("海澜");
    }

}
