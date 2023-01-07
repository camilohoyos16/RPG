using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

//public interface IInputController
//{
//    public IInputMap inputMap
//}

public class InputDevice
{
    public string DeviceId { get; }
    public TextAsset InputConfig;
}


public class InputDictionary: IEnumerator<InputDictionary>
{
    public const string AttackInputId = "attack_input";
    public const string InteractInputId = "interact_input";
    public const string JumpInputId = "jump_input";
    public const string MoveForwardInputId = "move_forward_input";
    public const string MoveBackInputId = "move_back_input";
    public const string MoveRightInputId = "move_right_input";
    public const string MoveLeftInputId = "move_left_input";

    public InputDictionary Current => throw new System.NotImplementedException();

    object IEnumerator.Current => throw new System.NotImplementedException();

    public void Dispose() {
        throw new System.NotImplementedException();
    }

    public bool MoveNext() {
        throw new System.NotImplementedException();
    }

    public void Reset() {
        throw new System.NotImplementedException();
    }
}

public class InputManager
{
    public const string PC_INPUT_DEVICE_ID = "pc";
    public const string PLAY_STATION_INPUT_DEVICE_ID = "ps";
    public const string XBOX_INPUT_DEVICE_ID = "xbox";

    private static InputDevice m_pcDevice;
    private static InputDevice m_xboxDevice;
    private static InputDevice m_playStationDevice;

    private static InputDevice? m_currentDevice;
    public static Dictionary<string, string> InputMap;

    public static bool WasInputUsed(string assignedInput, string usedInput) {
        // gURADAR EL INPUT EN lower case para evitar hacer el split y tener que gaurdar mas de un input con la separacion
        // Lo de arriba se implementara a la mitad, si se guardara en lower case, pero se dejara el split
        // para facilitar el cambio de control: xbox, play, teclado, etc. En ese caso el contenido quedara algo asi: "shift|x|square"
        /// NOTE: no se tomara un desicion hasta no empezar a conectar y mirar como son los inputs
        string[] staticInputs = assignedInput.Split('|');
        foreach (string input in staticInputs) {
            if (input.Equals(usedInput)) {
                return true;
            }
        }
        return false;
    }

    //public static void UpdateInputs() {
    //    Keyboard.current.b
    //}

    private static InputDevice? GetInputDeviceById(string id) => id switch {
        PC_INPUT_DEVICE_ID => m_pcDevice,
        XBOX_INPUT_DEVICE_ID => m_xboxDevice,
        PLAY_STATION_INPUT_DEVICE_ID => m_playStationDevice,
        _ => null,
    };

    private static void InitializeDevice() {
        m_currentDevice = GetInputDeviceById(PC_INPUT_DEVICE_ID);
        InitializeInputs();
    }

    private static void InitializeInputs() {
        TextAsset file = new TextAsset();

        Dictionary<string, string> pcInputs = new();
        pcInputs = JsonUtility.FromJson<Dictionary<string, string>>(file.text);
        InputMap = new (){
            { InputDictionary.AttackInputId, pcInputs[InputDictionary.AttackInputId] },
            { InputDictionary.InteractInputId, pcInputs[InputDictionary.InteractInputId] },
            { InputDictionary.JumpInputId, pcInputs[InputDictionary.JumpInputId] },
            { InputDictionary.MoveForwardInputId, pcInputs[InputDictionary.MoveForwardInputId] },
            { InputDictionary.MoveBackInputId, pcInputs[InputDictionary.MoveBackInputId] },
            { InputDictionary.MoveRightInputId, pcInputs[InputDictionary.MoveRightInputId] },
            { InputDictionary.MoveLeftInputId, pcInputs[InputDictionary.MoveLeftInputId] },
        };
    }

    public static void ChangeDevice(InputDevice device) {
        m_currentDevice = device;

        UpdateInputMap();
    }

    private static void UpdateInputMap() {
        TextAsset file = m_currentDevice.InputConfig;

        Dictionary<string, string> newInputs = new();
        newInputs = JsonUtility.FromJson<Dictionary<string, string>>(file.text);

        foreach (KeyValuePair<string, string> input in newInputs) {
            if (InputMap.ContainsKey(input.Key)) {
                InputMap[input.Key] = input.Value;
            }
        }
    }

    public static string GetInputByAction(string actionId) {
        switch (actionId) {
            case ActionsDictionary.ATTACK_MELEE_ACTION_ID:
                return InputMap[InputDictionary.AttackInputId];
            case ActionsDictionary.INTERACT_ACTION_ID:
                return InputMap[InputDictionary.InteractInputId];
            case ActionsDictionary.JUMP_ACTION_ID:
                return InputMap[InputDictionary.JumpInputId];
            case ActionsDictionary.MOVE_FORWARD_ACTION_ID:
                return InputMap[InputDictionary.MoveForwardInputId];
            case ActionsDictionary.MOVE_BACK_ACTION_ID:
                return InputMap[InputDictionary.MoveBackInputId];
            case ActionsDictionary.MOVE_LEFT_ACTION_ID:
                return InputMap[InputDictionary.MoveLeftInputId];
            case ActionsDictionary.MOVE_RIGHT_ACTION_ID:
                return InputMap[InputDictionary.MoveRightInputId];
            default:
                return "";
        }
    }
}
