using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ApplicationFacade.Instance.StartUp();
        ApplicationFacade.Instance.SendNotification(ApplicationConstants.GameStart);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

        }
    }
}
