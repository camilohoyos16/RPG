using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using Newtonsoft.Json;

//public interface IInputController
//{
//    public IInputMap inputMap
//}

public class InputContext
{
    public List<string> InputsUsedId;
}

public static class InputActionsIdDictionary
{
    public const string AttackInputId = "attack_input";
    public const string InteractInputId = "interact_input";
    public const string JumpInputId = "jump_input";
    public const string MoveForwardInputId = "move_forward_input";
    public const string MoveBackInputId = "move_back_input";
    public const string MoveRightInputId = "move_right_input";
    public const string MoveLeftInputId = "move_left_input";
}

public class InputUtilities
{
    /// <summary>
    /// This is the id new Input Sytem from Unity is providing
    /// </summary>
    private const int KEYBOARD_INPUT_SYSTEM_ID = 1;
    private const int MOUSE_INPUT_SYSTEM_ID = 2;
    private const int PS4_CONTROLLER_INPUT_SYSTEM_ID = 18;
    private const int XBOX_ONE_CONTROLLER_INPUT_SYSTEM_ID = 14;

    /// <summary>
    /// This is the id we are using inside the game to be clearer.
    /// </summary>
    public const string PC_INPUT_DEVICE_ID = "pc";
    public const string PLAY_STATION_4_INPUT_DEVICE_ID = "ps4";
    public const string XBOX_ONE_INPUT_DEVICE_ID = "xbox_one";

    private static GameInputDevice m_pcDevice;
    private static GameInputDevice m_xboxDevice;
    private static GameInputDevice m_playStationDevice;

    public static GameInputDevice? m_currentDevice;
    public static Dictionary<string, string> InputMap = new Dictionary<string, string>();

    public static bool WasActionInputTriggered(string actionInput, string usedInput)
    {
        // gURADAR EL INPUT EN lower case para evitar hacer el split y tener que gaurdar mas de un input con la separacion
        // Lo de arriba se implementara a la mitad, si se guardara en lower case, pero se dejara el split
        // para facilitar el cambio de control: xbox, play, teclado, etc. En ese caso el contenido quedara algo asi: "shift|x|square"
        /// NOTE: no se tomara un desicion hasta no empezar a conectar y mirar como son los inputs
        string[] staticInputs = actionInput.Split('|');
        foreach (string input in staticInputs)
        {
            if (input.Equals(usedInput))
            {
                return true;
            }
        }
        return false;
    }

    private static GameInputDevice? GetInputDeviceById(string id) => id switch
    {
        PC_INPUT_DEVICE_ID => m_pcDevice,
        XBOX_ONE_INPUT_DEVICE_ID => m_xboxDevice,
        PLAY_STATION_4_INPUT_DEVICE_ID => m_playStationDevice,
        _ => null,
    };

    public static void ChangeDevice(GameInputDevice device)
    {
        m_currentDevice = device;

        UpdateInputMap();
    }

    private static void UpdateInputMap()
    {
        foreach (KeyValuePair<string, string> input in m_currentDevice.InputConfig)
        {
            if (InputMap.ContainsKey(input.Key))
            {
                InputMap[input.Key] = input.Value;
            }
        }
    }

    public static Dictionary<string, string> ParseDeviceConfigFromFile(TextAsset file)
    {
        Dictionary<string, string> newInputs = new();
        newInputs = JsonUtility.FromJson<Dictionary<string, string>>(file.text);
        return newInputs;
    }

    public static string GetInputByAction(string actionId)
    {
        switch (actionId)
        {
            case ActionsDictionary.ATTACK_MELEE_ACTION_ID:
                return InputMap[InputActionsIdDictionary.AttackInputId];
            case ActionsDictionary.INTERACT_ACTION_ID:
                return InputMap[InputActionsIdDictionary.InteractInputId];
            case ActionsDictionary.JUMP_ACTION_ID:
                return InputMap[InputActionsIdDictionary.JumpInputId];
            case ActionsDictionary.MOVE_FORWARD_ACTION_ID:
                return InputMap[InputActionsIdDictionary.MoveForwardInputId];
            case ActionsDictionary.MOVE_BACK_ACTION_ID:
                return InputMap[InputActionsIdDictionary.MoveBackInputId];
            case ActionsDictionary.MOVE_LEFT_ACTION_ID:
                return InputMap[InputActionsIdDictionary.MoveLeftInputId];
            case ActionsDictionary.MOVE_RIGHT_ACTION_ID:
                return InputMap[InputActionsIdDictionary.MoveRightInputId];
            default:
                return "";
        }
    }

    public static string GetDeviceIdFromUnityInputSystemId(int id) => id switch
    {
        KEYBOARD_INPUT_SYSTEM_ID | MOUSE_INPUT_SYSTEM_ID => PC_INPUT_DEVICE_ID,
        XBOX_ONE_CONTROLLER_INPUT_SYSTEM_ID => XBOX_ONE_INPUT_DEVICE_ID,
        PS4_CONTROLLER_INPUT_SYSTEM_ID => PLAY_STATION_4_INPUT_DEVICE_ID,
        _ => string.Empty,
    };
}
