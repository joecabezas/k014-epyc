using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.Events;
using System;

public class EventManager : MonoBehaviour
{

    private Dictionary<object, GenericUnityEvent> eventDictionary;

    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<object, GenericUnityEvent>();
        }
    }

    public static void StartListening(object eventName, UnityAction<object> listener)
    {
        GenericUnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new GenericUnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(object eventName, UnityAction<object> listener)
    {
        if (eventManager == null) return;
        GenericUnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(object eventName)
    {
        TriggerEvent(eventName, null);
    }

    public static void TriggerEvent(object eventName, object context)
    {
        GenericUnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(context);
        }
    }
}