using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JoinMatchUI : MonoBehaviour {

    //public static string BACK_BUTTON_ON_CLICK = "BACK_BUTTON_ON_CLICK";
    //public static string CONNECT_BUTTON_ON_CLICK = "CONNECT_BUTTON_ON_CLICK";

    public enum EVENTS
    {
        BACK_BUTTON_ON_CLICK,
        CONNECT_BUTTON_ON_CLICK
    }

    public Button backButton;
    public Button connectButton;

    public TMP_InputField inputField;

	// Use this for initialization
	void Start () {
        backButton.onClick.AddListener(OnBackButtonClickHandler);
        connectButton.onClick.AddListener(OnConnectButtonClickHandler);
    }

    private void OnConnectButtonClickHandler()
    {
        string serverAddress = inputField.text;
        EventManager.TriggerEvent(EVENTS.CONNECT_BUTTON_ON_CLICK, serverAddress);
    }

    private void OnBackButtonClickHandler()
    {
        EventManager.TriggerEvent(EVENTS.BACK_BUTTON_ON_CLICK);
        Debug.Log(EVENTS.BACK_BUTTON_ON_CLICK.GetHashCode());
    }
}
