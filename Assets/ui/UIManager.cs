using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject matchLobbyUI;
    public GameObject joinMatchUI;

    void Start()
    {
        showMainMenuUI();

        EventManager.StartListening(CustomNetworkManager.EVENTS.START_HOST, OnStartHostHandler);
        EventManager.StartListening(CustomNetworkManager.EVENTS.STOP_HOST, OnStopHostHandler);
        EventManager.StartListening(CustomNetworkManager.EVENTS.START_CLIENT, OnStartClient);
        EventManager.StartListening(CustomNetworkManager.EVENTS.STOP_CLIENT, OnStopClient);

        EventManager.StartListening(MainMenuUI.EVENTS.JOIN_MATCH_CLICK_BUTTON, OnJoinMatchButtonClickHandler);

        EventManager.StartListening(MatchLobbyUI.EVENTS.BACK_BUTTON_ON_CLICK, OnMatchLobbyBackButtonClickHandler);

        EventManager.StartListening(JoinMatchUI.EVENTS.BACK_BUTTON_ON_CLICK, OnBackButtonClickHandler);
        EventManager.StartListening(JoinMatchUI.EVENTS.CONNECT_BUTTON_ON_CLICK, OnConnectButtonClickHandler);
    }

    private void OnStopClient(object arg0)
    {
        showMainMenuUI();
    }

    private void OnStartClient(object arg0)
    {
        //TODO
    }

    private void OnStopHostHandler(object arg0)
    {
        showMainMenuUI();
    }

    private void OnMatchLobbyBackButtonClickHandler(object arg0)
    {
        showMainMenuUI();
    }

    private void OnConnectButtonClickHandler(object arg0)
    {
        showMatchLobbyUI();
    }

    private void OnBackButtonClickHandler(object arg0)
    {
        showMainMenuUI();
    }

    private void OnJoinMatchButtonClickHandler(object arg0)
    {
        showJoinMatchUI();
    }

    private void showJoinMatchUI()
    {
        HideAllUI();
        joinMatchUI.SetActive(true);
    }

    private void showMainMenuUI()
    {
        HideAllUI();
        mainMenuUI.SetActive(true);
    }

    private void OnStartHostHandler(object arg0)
    {
        showMatchLobbyUI();
    }

    private void showMatchLobbyUI()
    {
        HideAllUI();
        matchLobbyUI.SetActive(true);
    }

    private void OnCreateMatchButtonHandler(object context)
    {
        showMatchLobbyUI();
    }

    private void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        matchLobbyUI.SetActive(false);
        joinMatchUI.SetActive(false);
    }
}
