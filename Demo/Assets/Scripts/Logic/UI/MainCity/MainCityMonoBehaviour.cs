using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCityMonoBehaviour : IMonoBehaviour
{
    public List<Func<UnityMediator>> ListUnityMediatorInterests()
    {
        var funcs = new List<Func<UnityMediator>>();
        funcs.Add(() => new MainCityMediator_0(nameof(MainCityMediator_0)));
        return funcs;
    }

}
