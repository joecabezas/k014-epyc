using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMatchButton : MonoBehaviour
{
    public static string CREATE_MATCH_BUTTON_ON_CLICK = "CREATE_MATCH_BUTTON_ON_CLICK";

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickHandler);
    }

    private void OnClickHandler()
    {
        EventManager.TriggerEvent(CREATE_MATCH_BUTTON_ON_CLICK);
    }
}
