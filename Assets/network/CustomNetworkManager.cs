using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class CustomNetworkManager : NetworkManager
{
    public enum EVENTS
    {
        START_HOST,
        STOP_HOST,
        START_CLIENT,
        STOP_CLIENT,

        CLIENT_CONNECT,
        CLIENT_DISCONNECT,

        SERVER_ADD_PLAYER,
        SERVER_REMOVE_PLAYER,
        SERVER_DISCONNECT
    }

    public static int MAX_CONNECTIONS = 4;
    public static int PORT_NUMBER = 1004;
    
    private void Start()
    {
        base.networkPort = PORT_NUMBER;
        base.connectionConfig.AddChannel(QosType.Reliable);
        base.connectionConfig.AddChannel(QosType.Unreliable);

        //creates host
        EventManager.StartListening(MainMenuUI.EVENTS.CREATE_MATCH_CLICK_BUTTON, OnCreateMatchButtonClickHandler);
        //creates client
        EventManager.StartListening(JoinMatchUI.EVENTS.CONNECT_BUTTON_ON_CLICK, OnConnectButtonClickHandler);

        //disconnect
        EventManager.StartListening(MatchLobbyUI.EVENTS.BACK_BUTTON_ON_CLICK, OnBackToMainMenuHandler);
        EventManager.StartListening(JoinMatchUI.EVENTS.BACK_BUTTON_ON_CLICK, OnBackToMainMenuHandler);
    }

    private void OnConnectButtonClickHandler(object context)
    {
        string serverAddress = (string)context;
        base.networkAddress = serverAddress.Split(':')[0];
        base.networkPort = Int32.Parse(serverAddress.Split(':')[1]);
        base.StartClient();
    }

    private void OnBackToMainMenuHandler(object context)
    {
        DisconnectAll();
    }

    private void DisconnectAll()
    {
        Debug.Log(">>>DisconnectAll");

        if (NetworkServer.active || base.IsClientConnected())
        {
            Debug.Log(">>>base.StopHost()2");
            Debug.Log(">>>NetworkServer.active:" + NetworkServer.active);
            Debug.Log(">>>base.IsClientConnected():" + base.IsClientConnected());
            base.StopHost();
        }
    }

    private void OnCreateMatchButtonClickHandler(object context)
    {
        base.StartHost();
    }
    public override void OnStartHost()
    {
        Debug.Log(">>>OnStartHost");
        base.OnStartHost();
        EventManager.TriggerEvent(EVENTS.START_HOST);
    }

    public override void OnStopHost()
    {
        Debug.Log(">>>OnStopHost");
        base.OnStopHost();
        EventManager.TriggerEvent(EVENTS.STOP_HOST);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Debug.Log(">>>OnServerAddPlayer");
        GameObject player = (GameObject)Instantiate(base.playerPrefab, GameManager.Instance.lobbyPlayersContainer);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

        EventManager.TriggerEvent(EVENTS.SERVER_ADD_PLAYER);
    }

    public override void OnServerRemovePlayer(NetworkConnection conn, PlayerController player)
    {
        Debug.Log(">>>OnServerRemovePlayer");
        base.OnServerRemovePlayer(conn, player);
        EventManager.TriggerEvent(EVENTS.SERVER_REMOVE_PLAYER);
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        Debug.Log(">>>OnServerDisconnect");
        base.OnServerDisconnect(conn);
        EventManager.TriggerEvent(EVENTS.SERVER_DISCONNECT);
    }

    public override void OnStartClient(NetworkClient client)
    {
        Debug.Log(">>>OnStartClient");
        base.OnStartClient(client);
        EventManager.TriggerEvent(EVENTS.START_CLIENT);
    }

    public override void OnStopClient()
    {
        Debug.Log(">>>OnStopClient");
        base.OnStopClient();
        EventManager.TriggerEvent(EVENTS.STOP_CLIENT);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log(">>>OnClientConnect");
        base.OnClientConnect(conn);
        EventManager.TriggerEvent(EVENTS.CLIENT_CONNECT, conn);
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log(">>>OnClientDisconnect");
        base.OnClientDisconnect(conn);
        EventManager.TriggerEvent(EVENTS.CLIENT_DISCONNECT, conn);
    }
}
