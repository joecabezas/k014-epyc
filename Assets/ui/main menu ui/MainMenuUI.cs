using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    public enum EVENTS
    {
        CREATE_MATCH_CLICK_BUTTON,
        JOIN_MATCH_CLICK_BUTTON
    }

    public Button createMatchButton;
    public Button joinMatchButton;

    void Start () {
        createMatchButton.onClick.AddListener(OnCreateMatchButton);
        joinMatchButton.onClick.AddListener(OnJoinMatchButton);
    }

    private void OnJoinMatchButton()
    {
        EventManager.TriggerEvent(EVENTS.JOIN_MATCH_CLICK_BUTTON);
    }

    private void OnCreateMatchButton()
    {
        EventManager.TriggerEvent(EVENTS.CREATE_MATCH_CLICK_BUTTON);
    }
}
