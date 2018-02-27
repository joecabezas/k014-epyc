using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MatchLobbyUI : MonoBehaviour
{
    //public static string BACK_BUTTON_ON_CLICK = "BACK_BUTTON_ON_CLICK";
    //public static string START_MATCH_BUTTON_ON_CLICK = "START_MATCH_BUTTON_ON_CLICK";

    public enum EVENTS
    {
        BACK_BUTTON_ON_CLICK,
        START_MATCH_BUTTON_ON_CLICK
    }

    public Button backButton;
    public Button startMatchButton;

    public GameObject loadingGameObject;
    public GameObject playerListGameObject;

    public Transform playerListContainerTransform;

    public GameObject playerLobbyItemPrefab;

    // Use this for initialization
    void Start()
    {
        ShowLoadingUI();

        backButton.onClick.AddListener(OnBackButtonHandler);
        startMatchButton.onClick.AddListener(OnStartMatchButtonHandler);

        EventManager.StartListening(CustomNetworkManager.EVENTS.SERVER_ADD_PLAYER, OnServerAddPlayerHandler);
        EventManager.StartListening(CustomNetworkManager.EVENTS.SERVER_REMOVE_PLAYER, OnServerRemovePlayerHandler);

        EventManager.StartListening(CustomNetworkManager.EVENTS.SERVER_DISCONNECT, OnServerDisconnectHandler);

        EventManager.StartListening(CustomNetworkManager.EVENTS.CLIENT_CONNECT, OnClientConnectHandler);
    }

    private void OnClientConnectHandler(object arg0)
    {
        Debug.Log(">>>MatchLobbyUI::OnClientConnectHandler");
        UpdatePlayerList();
    }

    private void OnServerDisconnectHandler(object arg0)
    {
        Debug.Log(">>>MatchLobbyUI::OnServerDisconnectHandler");
        UpdatePlayerList();
    }

    private void OnServerRemovePlayerHandler(object arg0)
    {
        Debug.Log(">>>MatchLobbyUI::OnServerRemovePlayerHandler");
        UpdatePlayerList();
    }

    private void OnServerAddPlayerHandler(object arg0)
    {
        Debug.Log(">>>MatchLobbyUI::OnServerAddPlayerHandler");
        showPlayerListUI();
        UpdatePlayerList();
    }

    private void UpdatePlayerList()
    {
        CleanPlayerList();

        //get player list and create players again
        //foreach(LobbyPlayer lobbyPlayer in GameManager.Instance.getLobbyPlayers())
        //{
        //    AddPlayerToLobbyList(lobbyPlayer);
        //}

        foreach (KeyValuePair<NetworkInstanceId, NetworkIdentity> pair in ClientScene.objects)
        {
            AddPlayerToLobbyList(pair);
        }
    }

    private void AddPlayerToLobbyList(KeyValuePair<NetworkInstanceId, NetworkIdentity> pair)
    {
        Debug.Log(">>>AddPlayerToLobbyList");
        Instantiate(playerLobbyItemPrefab, playerListContainerTransform);
    }

    private void CleanPlayerList()
    {
        foreach (Transform child in playerListContainerTransform)
        {
            Destroy(child.gameObject);
        }
    }

    private void OnStartMatchButtonHandler()
    {
        EventManager.TriggerEvent(EVENTS.START_MATCH_BUTTON_ON_CLICK);
    }

    private void OnBackButtonHandler()
    {
        EventManager.TriggerEvent(EVENTS.BACK_BUTTON_ON_CLICK);
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

    private void showPlayerListUI()
    {
        HideAllUI();
        playerListGameObject.SetActive(true);
    }
}
