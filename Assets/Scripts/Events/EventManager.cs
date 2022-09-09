using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventArgs
{

}

public class EventManager : MonoBehaviour
{
    private static EventManager instance;
    public static EventManager Instance {
        get {
            if (instance == null) {
                GameObject instanceObject = new GameObject("EventManager");
                instance = instanceObject.AddComponent<EventManager>();
            }

            return instance;
        }
    }

    private Dictionary<string, Dictionary<int, Action<GlobalEvent>>>  m_eventsRegister = new();

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void OnRegisterEntity(OnRegisterEntityEvent e ) {
    }

    // Start is called before the first frame update
    void Start() {
    }

    public void Register<T>(object classInstance, Action<T> method) where T: GlobalEvent {
        AddNewListener(typeof(T).FullName, classInstance, method);
    }

    private void AddNewListener<T>(string eventType, object objectInstance, Action<T> method) where T : GlobalEvent {
        if (!m_eventsRegister.ContainsKey(eventType)) {
            m_eventsRegister.Add(eventType, new());
        }

        if (!m_eventsRegister[eventType].ContainsKey(objectInstance.GetHashCode())) {
            m_eventsRegister[eventType].Add(objectInstance.GetHashCode(), (args) => { method((T)args); });
        }
    }

    public void TriggerGlobal(GlobalEvent eventInstance) {
        string eventKey = eventInstance.GetType().Name;
        if (m_eventsRegister.ContainsKey(eventKey)) {
            foreach (Action<GlobalEvent> methods in m_eventsRegister[eventKey].Values) {
                methods?.Invoke(eventInstance);
            }
        }
    }

    public void TriggerGlobalAndObject(GlobalEvent eventInstance, object objectinstance) {
        string eventKey = eventInstance.GetType().Name;
        int objectKey = objectinstance.GetHashCode();
        if (m_eventsRegister.ContainsKey(eventKey)) {
            if (m_eventsRegister[eventKey].ContainsKey(objectKey)) {
                m_eventsRegister[eventKey][objectKey].Invoke(eventInstance);
            }
        }
    }

    /// Need to use codegen but it is not the main priority right now.
    /// It could be directly from here, visual studio, or in unity
    //public void Register<T>(T classInstance) where T : class {
    //    Type classType = classInstance.GetType();
    //    foreach (MethodInfo method in classType.GetMethods()) {
    //        Attribute eventAttribute = method.GetCustomAttribute(typeof(EventListener));
    //        if (eventAttribute != null) {
    //            ParameterInfo[] parameters = method.GetParameters();
    //            AddNewListener(parameters[0].ParameterType.FullName, classInstance, method);
    //        }
    //    }
    //}

    //public void TriggerGlobal(GlobalEvent eventInstance){
    //    if (m_eventsRegister.ContainsKey(eventInstance.GetType().Name)) {
    //        foreach (EventsDelegate methods in m_eventsRegister[eventInstance.GetType().Name].Values) {
    //            methods?.Invoke(eventInstance);
    //        } 
    //    }
    //}

    //private void AddNewListener(string eventType, object objectInstance, MethodInfo methodInfo ) {
    //    EventsDelegate tempMethod =  (EventsDelegate)methodInfo.CreateDelegate(typeof(EventsDelegate), objectInstance);
    //    EventsDelegate method =  (EventsDelegate)methodInfo.CreateDelegate(typeof(EventsDelegate), objectInstance);
    //    if (!m_eventsRegister.ContainsKey(eventType)) {
    //        m_eventsRegister.Add(eventType, new());
    //    }

    //    if (!m_eventsRegister[eventType].ContainsKey(objectInstance.GetHashCode())){
    //        m_eventsRegister[eventType].Add(objectInstance.GetHashCode(), method);
    //    }
    //}
}

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class EventListener : System.Attribute
{
}