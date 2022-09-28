using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    /// <summary>
    /// All of this should be made with WorldMnager but instantiating a prefab
    /// </summary>
    public static WorldManager Instance;
    //public static WorldManager Instance {
    //    get {
    //        if (instance == null) {
    //            GameObject instanceObject = new GameObject("EventManager");
    //            instance = instanceObject.AddComponent<EventManager>();
    //        }

    //        return instance;
    //    }
    //}

    private void Awake() {
        Instance = this;
    }

    public DynamicStatsDatabase DynamicStatsDatabaseInstance;
}
