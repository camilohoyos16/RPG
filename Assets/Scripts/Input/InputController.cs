using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    public InputDevicesDatabase InputDevicesDatabase;

    public List<GameInputDevice> Devices;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        CreateDevicesConfigs();
    }

    private void CreateDevicesConfigs()
    {
        foreach (KeyValuePair<string, GameInputDeviceConfig> deviceConfig in InputDevicesDatabase.GetDevices())
        {
            Devices.Add(new GameInputDevice(deviceConfig.Value));
        }
    }

}
