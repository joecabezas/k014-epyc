using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class MatchLobbyUI : MonoBehaviour
{

    public GameObject loadingGameObject;
    public GameObject playerListGameObject;

    public Transform playerListContainerTransform;

    // Use this for initialization
    void Start()
    {
        ShowLoadingUI();
        EventManager.StartListening(CustomNetworkManager.MATCH_CREATED, OnMatchCreatedHandler);
    }

    private void ShowLoadingUI()
    {
        HideAllUI();
        loadingGameObject.SetActive(true);
    }

    private void HideAllUI()
    {
        loadingGameObject.SetActive(false);
        playerListGameObject.SetActive(false);
    }

    private void OnMatchCreatedHandler(object context)
    {
        showPlayerListUI();
        MatchInfo matchInfo = (MatchInfo)context;
        Debug.Log(matchInfo.ToString());
    }

    private void showPlayerListUI()
    {
        HideAllUI();
        playerListGameObject.SetActive(true);
    }
}
