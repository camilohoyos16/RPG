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
        var myAction = new UnityEngine.InputSystem.InputAction(type: InputActionType.Button, binding: "/<Mouse>/leftButton");
        myAction.performed += CheckMouse;
    }

    // Update is called once per frame
    void Update()
    {
        //var myAction = new UnityEngine.InputSystem.InputAction (binding: "<Mouse>/<button>");
        //myAction.performed += CheckMouse;

        if (Input.GetKey(KeyCode.Space))
        {
            CheckDevices();
        }

        //if (Input.GetKey(KeyCode.J))
        //{
        //    ToJson();
        //}


    }

    private void CheckMouse(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log(context.control.name);
    }

    private void ToJson()
    {
        Dictionary<string, string> inputs = new()
        {
            { ActionsDictionary.PAUSE_GAME_ACTION_ID, "P" },
            { ActionsDictionary.ATTACK_ACTION_ID, "a" },
            { ActionsDictionary.INTERACT_ACTION_ID, "E" },
            { ActionsDictionary.JUMP_ACTION_ID, "SPACE" },
            { ActionsDictionary.MOVE_FORWARD_ACTION_ID, "W" },
            { ActionsDictionary.MOVE_BACK_ACTION_ID, "S" },
            { ActionsDictionary.MOVE_RIGHT_ACTION_ID, "D" },
            { ActionsDictionary.MOVE_LEFT_ACTION_ID, "A" },
        };

        string json = string.Empty;
        json = JsonConvert.SerializeObject(inputs, new JsonSerializerSettings
        {
            StringEscapeHandling = StringEscapeHandling.EscapeHtml,
            TypeNameHandling = TypeNameHandling.Auto
        });
        Debug.LogError(json);
    }

    private void CheckDevices()
    {
        ReadOnlyArray<InputDevice> devices = InputSystem.devices;
        if (Mouse.current.wasUpdatedThisFrame)
        {
            Debug.Log(Mouse.current.press.name);
        }
        ReadOnlyArray<Gamepad> gamepads = Gamepad.all;

    }
}
