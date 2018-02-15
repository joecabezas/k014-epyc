using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject createMatchUI;
    public GameObject matchLobbyUI;
    public GameObject JoinMatchUI;

    void Start()
    {
        showMainMenuUI();
        EventManager.StartListening(CreateMatchButton.CREATE_MATCH_BUTTON_ON_CLICK, OnCreateMatchButtonHandler);
        EventManager.StartListening(CreateMatchOkButton.CREATE_MATCH_OK_BUTTON_ON_CLICK, OnCreateMatchOkButtonHandler);
    }

    private void showMainMenuUI()
    {
        HideAllUI();
        mainMenuUI.SetActive(true);
    }

    private void OnCreateMatchOkButtonHandler(object arg0)
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
        showCreateMatchUI();
    }

    private void showCreateMatchUI()
    {
        HideAllUI();
        createMatchUI.SetActive(true);
    }

    private void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        createMatchUI.SetActive(false);
        matchLobbyUI.SetActive(false);
        JoinMatchUI.SetActive(false);
    }
}
