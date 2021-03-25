using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 注册所有的Mediator
/// </summary>
public class LoginMonoBehaviour : IMonoBehaviour
{
    public List<Func<UnityMediator>> ListUnityMediatorInterests()
    {
        var funcs = new List<Func<UnityMediator>>();
        funcs.Add(() => new LoginMediator_0(nameof(LoginMediator_0)));
        funcs.Add(() => new LoginMediator_1(nameof(LoginMediator_1)));
        return funcs;
    }
}
