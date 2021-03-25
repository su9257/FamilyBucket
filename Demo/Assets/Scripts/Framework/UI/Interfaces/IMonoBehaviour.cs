using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public interface IMonoBehaviour 
{
    List<Func<UnityMediator>> ListUnityMediatorInterests();
}
