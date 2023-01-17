using UnityEngine;

[CreateAssetMenu(fileName = "new_InptDevice", menuName = "Input/New Device", order = 1)]
public class GameInputDeviceConfig : ScriptableObject
{
    public string DeviceId;
    public TextAsset InputConfig;
}