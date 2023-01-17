using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using Newtonsoft.Json;

public class InputTest : MonoBehaviour
{
    private void Start()
    {
        InputSystem.onDeviceChange +=
        (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    // New Device.
                    break;
                case InputDeviceChange.Disconnected:
                    // Device got unplugged.
                    break;
                case InputDeviceChange.Reconnected:
                    // Plugged back in.
                    break;
                case InputDeviceChange.Removed:
                    // Remove from Input System entirely; by default, Devices stay in the system once discovered.
                    break;
                default:
                    // See InputDeviceChange reference for other event types.
                    break;
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            CheckDevices();
        }

        if (Input.GetKey(KeyCode.J))
        {
            ToJson();
        }


    }

    private void ToJson()
    {
        Dictionary<string, string> inputs = new()
        {
            { InputActionsIdDictionary.AttackInputId, "a" },
            { InputActionsIdDictionary.InteractInputId, "s" },
            { InputActionsIdDictionary.JumpInputId, "f" },
            { InputActionsIdDictionary.MoveForwardInputId, " " },
            { InputActionsIdDictionary.MoveBackInputId, "e" },
            { InputActionsIdDictionary.MoveRightInputId, "j" },
            { InputActionsIdDictionary.MoveLeftInputId, "i" },
        };

        string json = string.Empty;
        json = JsonConvert.SerializeObject(inputs, new JsonSerializerSettings
        {
            StringEscapeHandling = StringEscapeHandling.EscapeHtml,
            TypeNameHandling = TypeNameHandling.Auto
        }) ;
        Debug.LogError(json);
    }

    private void CheckDevices()
    {
        ReadOnlyArray<InputDevice> devices = InputSystem.devices;
        ReadOnlyArray<Gamepad> gamepads = Gamepad.all;

    }
}
