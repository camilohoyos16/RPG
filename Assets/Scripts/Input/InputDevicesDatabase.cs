using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_InputDatabase", menuName = "Input/Database", order = 1)]

public class InputDevicesDatabase : ScriptableObject
{
    [SerializeField]
    private List<GameInputDeviceConfig> DevicesConfigList;

    private Dictionary<string, GameInputDevice> DevicesConfig;

    public void Init()
    {
        DevicesConfig = new();

        foreach (GameInputDeviceConfig deviceConfig in DevicesConfigList)
        {
            if (!DevicesConfig.ContainsKey(deviceConfig.DeviceId))
            {
                DevicesConfig.Add(deviceConfig.DeviceId, new GameInputDevice(deviceConfig));
            }
        }
    }

    public GameInputDevice? GetGameInputDeviceConfigById(string id)
    {
        if (DevicesConfig.ContainsKey(id))
        {
            return DevicesConfig[id];
        }
        return null;
    }

    public Dictionary<string, GameInputDevice> GetDevices()
    {
        return DevicesConfig;
    }
}
