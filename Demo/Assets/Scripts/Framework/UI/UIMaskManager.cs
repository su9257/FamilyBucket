using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Core;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVC.Patterns.Command;
using PureMVC.Patterns.Facade;
using PureMVC.Patterns.Mediator;
using PureMVC.Patterns.Observer;
using PureMVC.Patterns.Proxy;
using Sirenix.OdinInspector;


public class UIMaskManager : SingletonMonoBehaviour<UIMaskManager>
{

    public enum UIMaskType
    {
        None, Light, Dark
    }
    public void CreateMask(Transform panelTransfrom, UIMaskType uIMaskType, Action onClick)
    {
        string suffix = uIMaskType== UIMaskType.Light? "Light": "Dark";
        GameObject temp = Instantiate(Resources.Load<GameObject>("Prefabs/MaskImage"+ suffix));
        temp.transform.SetParent(panelTransfrom, false);
        temp.transform.SetAsFirstSibling();
        //temp.GetComponent<AnimatedButton>().onClick.AddListener(()=>onClick?.Invoke()); 
    }

}
