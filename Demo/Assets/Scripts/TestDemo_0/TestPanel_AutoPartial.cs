//using PureMVC.Interfaces;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///// <summary>
///// 此脚本为自动生成，请勿手动更改
///// </summary>
//public partial class TestPanel : IMonoBehaviour
//{
//    private readonly List<IMediator> tempMediators = new List<IMediator>();

//    void IMonoBehaviour.Awake()
//    {
//        GetMediatorInterests();
//        MediatorsRegisterHandle();
//    }
//    private void GetMediatorInterests()
//    {
//        var mediatorFactorys = ListMediatorFuncInterests();
//        for (int i = 0; i < mediatorFactorys.Length; i++)
//        {
//            tempMediators.Add(mediatorFactorys[i]());
//        }
//    }
//    private void MediatorsRegisterHandle()
//    {
//        for (int i = 0; i < tempMediators.Count; i++)
//        {
//            ApplicationFacade.Instance.RegisterMediator(tempMediators[i]);
//        }

//    }


//    private void MediatorsRemoveHandle()
//    {
//        tempMediators.Reverse();
//        for (int i = 0; i < tempMediators.Count; i++)
//        {
//            ApplicationFacade.Instance.RemoveMediator(tempMediators[i].MediatorName);
//        }
//        tempMediators.Clear();
//    }


//    void IMonoBehaviour.Start()
//    {

//    }
//}
