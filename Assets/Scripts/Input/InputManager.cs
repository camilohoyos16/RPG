using System.Collections.Generic;
using UnityEngine.InputSystem;

//public interface IInputController
//{
//    public IInputMap inputMap
//}

public interface IInputDevice
{
    public string DeviceId { get; }
}

public class XboxInputDevice : IInputDevice
{
    public string DeviceId => "";
}

public class PcInputDevice : IInputDevice
{
    public string DeviceId => throw new System.NotImplementedException();
}

public class PlayStationInputDevice : IInputDevice
{
    public string DeviceId => throw new System.NotImplementedException();
}

public class InputDictionary
{
    public const string AttackInputId = "attack_input";
    public const string InteractInputId = "interact_input";
    public const string JumpInputId = "jump_input";
    public const string MoveForwardInputId = "move_forward_input";
    public const string MoveBackInputId = "move_back_input";
    public const string MoveRightInputId = "move_right_input";
    public const string MoveLeftInputId = "move_left_input";
}

public class InputManager
{
    public const string PC_INPUT_DEVICE_ID = "pc";
    public const string PLAY_STATION_INPUT_DEVICE_ID = "ps";
    public const string XBOX_INPUT_DEVICE_ID = "xbox";

    private static IInputDevice m_currentDevice;
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

    public static void ChangeDevice(IInputDevice device) {
        m_currentDevice = device;

        UpdateInputMap();
    }

    private static void UpdateInputMap() {
        // Ned to create a json with a default config of input and override it when user change input inside game
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
