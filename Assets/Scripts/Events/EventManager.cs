using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class GlobalEvent
{

}

public class EventManager : MonoBehaviour
{
    private static EventManager instance;
    public static EventManager Instance {
        get { 
            if(instance == null) {
                GameObject instanceObject = new GameObject("EventManager");
                instance = instanceObject.AddComponent<EventManager>();
            }

            return instance;
        } 
    }

    private delegate void EventsDelegate(GlobalEvent reference);

    private Dictionary<string, Dictionary<int, EventsDelegate>> m_eventsRegister = new();

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
    }

    public void Register<T>(T classInstance) where T : class {
        Type classType = classInstance.GetType();
        foreach (MethodInfo method in classType.GetMethods()) {
            Attribute eventAttribute = method.GetCustomAttribute(typeof(EventListener));
            if (eventAttribute != null) {
                ParameterInfo[] parameters = method.GetParameters();
                AddNewListener(parameters[0].ParameterType.FullName, classInstance, method);
            }
        }
    }

    public void TriggerGlobal(GlobalEvent eventInstance){
        if (m_eventsRegister.ContainsKey(eventInstance.GetType().Name)) {
            foreach (EventsDelegate methods in m_eventsRegister[eventInstance.GetType().Name].Values) {
                methods?.Invoke(eventInstance);
            } 
        }
    }

    private void AddNewListener(string eventType, object objectInstance, MethodInfo methodInfo ) {
        EventsDelegate tempMethod =  (EventsDelegate)methodInfo.CreateDelegate(typeof(EventsDelegate), objectInstance);
        EventsDelegate method =  (EventsDelegate)methodInfo.CreateDelegate(typeof(EventsDelegate), objectInstance);
        if (!m_eventsRegister.ContainsKey(eventType)) {
            m_eventsRegister.Add(eventType, new());
        }

        if (!m_eventsRegister[eventType].ContainsKey(objectInstance.GetHashCode())){
            m_eventsRegister[eventType].Add(objectInstance.GetHashCode(), method);
        }
    }
}

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class EventListener : System.Attribute
{
}