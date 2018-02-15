using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class CustomNetworkManager : NetworkManager
{
    public static string MATCH_CREATED = "MATCH_CREATED";

    private void Start()
    {
        EventManager.StartListening(CreateMatchOkButton.CREATE_MATCH_OK_BUTTON_ON_CLICK, OnCreateMatchOkButtonHandler);
    }

    private void OnCreateMatchOkButtonHandler(object context)
    {
        if (matchMaker == null) { StartMatchMaker(); }

        string matchName = (string)context;
        matchMaker.CreateMatch(
            matchName,
            10,
            false,
            "",
            "",
            "",
            0,
            0,
            OnMatchCreatedHandler);
    }

    private void OnMatchCreatedHandler(bool success, string extendedInfo, MatchInfo responseData)
    {
        if (!success)
        {
            Debug.Log("Match Creation failed: " + extendedInfo);
            return;
        }

        //matchMaker.JoinMatch()
        EventManager.TriggerEvent(MATCH_CREATED, responseData);
    }
}
