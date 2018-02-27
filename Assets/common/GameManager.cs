using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;

    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    public Transform lobbyPlayersContainer;

    private void Start()
    {
        //EventManager.StartListening(CustomNetworkManager.EVENTS.CLIENT_CONNECT, OnClientConnectHandler);
        //EventManager.StartListening(CustomNetworkManager.EVENTS.CLIENT_DISCONNECT, OnClientDisconnectHandler);
    }

    private void OnClientDisconnectHandler(object context)
    {
        Debug.Log(">>>GameManager::OnClientDisconnectHandler");
        NetworkConnection nc = (NetworkConnection)context;
    }

    private void OnClientConnectHandler(object context)
    {
        Debug.Log(">>>GameManager::OnClientConnectHandler");
        NetworkConnection nc = (NetworkConnection)context;
        PlayerData playerData = new PlayerData();
        playerData.ConnectionId = nc.connectionId;
    }

    public List<LobbyPlayer> getLobbyPlayers()
    {
        List<LobbyPlayer> lobbyPlayerList = new List<LobbyPlayer>();
        lobbyPlayerList.AddRange(
            lobbyPlayersContainer.GetComponentsInChildren<LobbyPlayer>()
        );
        return lobbyPlayerList;
    }
}
