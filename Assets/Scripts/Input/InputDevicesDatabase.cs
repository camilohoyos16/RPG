using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_InptDevice", menuName = "Input/New Device", order = 1)]

public class InputDevicesDatabase : ScriptableObject
{
    [SerializeField]
    private GameInputDeviceConfig DevicesConfigList;

    private Dictionary<string, GameInputDeviceConfig> DevicesConfig;

    public GameInputDeviceConfig? GetGameInputDeviceConfigById(string id)
    {
        if (DevicesConfig.ContainsKey(id))
        {
            return DevicesConfig[id];
        }
        return null;
    }

    public Dictionary<string, GameInputDeviceConfig> GetDevices()
    {
        return DevicesConfig;
    }
}
