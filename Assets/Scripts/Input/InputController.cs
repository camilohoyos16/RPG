using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    public InputDevicesDatabase InputDevicesDatabase;

    public List<GameInputDevice> Devices;
    public static InputContext currentInputContext;
    private static InputUpdater currentInputUpdater;

    public static GameInputDevice m_currentDevice;

    /// <summary>
    /// This hold input map with key: actionId - value: inputName
    /// </summary>
    public static Dictionary<string, string> InputMap = new Dictionary<string, string>();
    /// <summary>
    /// This hold input map with key: inputName - value: actionId
    /// </summary>
    public static Dictionary<string, string> InputMapInverse = new Dictionary<string, string>();

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
        ChangeDevice(InputDevicesDatabase.GetGameInputDeviceConfigById(InputUtilities.PC_INPUT_DEVICE_ID));
    }

    private void CreateDevicesConfigs()
    {
        InputDevicesDatabase.Init();
    }

    public static void UpdateInputs()
    {
        currentInputContext.UpdateActionsUsed(currentInputUpdater.UpdateInputs().Values.ToList());
    }

    public static void ChangeDevice(GameInputDevice device)
    {
        m_currentDevice = device;

        switch (device.DeviceId)
        {
            case InputUtilities.PC_INPUT_DEVICE_ID:
                currentInputContext = new PcInputContext();
                currentInputUpdater = new PcInputUpdater();
                break;
            default:
                break;
        }

        UpdateInputMap();
    }

    private static void UpdateInputMap()
    {
        foreach (KeyValuePair<string, string> input in m_currentDevice.InputConfig)
        {
            if (!InputMap.ContainsKey(input.Key))
            {
                InputMap[input.Key] = input.Value;
                InputMapInverse[input.Value] = input.Key;
            }
        }
    }

    public static string GetActionInputByActionId(string actionId)
    {
        if (InputMap.ContainsKey(actionId))
        {
            return InputMap[actionId];
        }

        return string.Empty;
    }

    public static string GetActionByInput(string inputName)
    {
        if (InputMapInverse.ContainsKey(inputName))
        {
            return InputMapInverse[inputName];
        }

        return string.Empty;
    }

    public static InputActionResolver GetInputResolverByActionId(string actionId)
    {
        switch (actionId)
        {
            case ActionsDictionary.ATTACK_ACTION_ID:
            {
                return new GenericInputResolver();
            }
            case ActionsDictionary.INTERACT_ACTION_ID:
            {
                return new GenericInputResolver();
            }
            case ActionsDictionary.MOVE_FORWARD_ACTION_ID:
            case ActionsDictionary.MOVE_BACK_ACTION_ID:
            case ActionsDictionary.MOVE_LEFT_ACTION_ID:
            case ActionsDictionary.MOVE_RIGHT_ACTION_ID:
            {
                return new MoveForwardInputResolver();
            }
            default:
                return new GenericInputResolver();
        }
    }
}
