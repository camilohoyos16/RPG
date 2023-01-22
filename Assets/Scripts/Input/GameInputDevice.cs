using System.Collections.Generic;
public class GameInputDevice
{
    public string DeviceId { get; }
    public Dictionary<string, string> InputConfig;

    public GameInputDevice(GameInputDeviceConfig config)
    {
        DeviceId = config.DeviceId;
        InputConfig = InputUtilities.ParseDeviceConfigFromFile(config.InputConfig);
    }
}