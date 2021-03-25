using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPanel_0 : MonoBehaviour
{
    private void Awake()
    {
        ApplicationFacade.Instance.RegisterMediator(new TestPanel_0_Mediator_0(nameof(TestPanel_0_Mediator_0), this));
    }
    private void Start()
    {
        
    }

}
