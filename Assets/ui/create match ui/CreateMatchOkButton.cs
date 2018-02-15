using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateMatchOkButton : MonoBehaviour {

    public static string CREATE_MATCH_OK_BUTTON_ON_CLICK = "CREATE_MATCH_OK_BUTTON_ON_CLICK";
    public TMP_InputField inputField;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickHandler);
    }

    private void OnClickHandler()
    {
        EventManager.TriggerEvent(CREATE_MATCH_OK_BUTTON_ON_CLICK, inputField.text);
    }
}
