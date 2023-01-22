using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using Newtonsoft.Json;

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


    private static GameInputDevice? GetInputDeviceById(string id) => id switch
    {
        PC_INPUT_DEVICE_ID => m_pcDevice,
        XBOX_ONE_INPUT_DEVICE_ID => m_xboxDevice,
        PLAY_STATION_4_INPUT_DEVICE_ID => m_playStationDevice,
        _ => null,
    };

    public static Dictionary<string, string> ParseDeviceConfigFromFile(TextAsset file)
    {
        Dictionary<string, string> newInputs = new();
        newInputs = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.text, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        return newInputs;
    }

    public static string GetDeviceIdFromUnityInputSystemId(int id) => id switch
    {
        KEYBOARD_INPUT_SYSTEM_ID | MOUSE_INPUT_SYSTEM_ID => PC_INPUT_DEVICE_ID,
        XBOX_ONE_CONTROLLER_INPUT_SYSTEM_ID => XBOX_ONE_INPUT_DEVICE_ID,
        PS4_CONTROLLER_INPUT_SYSTEM_ID => PLAY_STATION_4_INPUT_DEVICE_ID,
        _ => string.Empty,
    };
}
