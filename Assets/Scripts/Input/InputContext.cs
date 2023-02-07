using System.Collections.Generic;
using UnityEngine;

public abstract class InputContext
{
    public abstract string DeviceId { get; }
    protected Dictionary<string, InputInfo> m_actionsPressedId = new ();
    public Vector2 CameraPointerChange;

    public void UpdateActionsUsed(List<InputInfo> actions)
    {
        m_actionsPressedId.Clear();

        foreach (InputInfo info in actions)
        {
            if(info.Value != 0)
            {
                m_actionsPressedId.Add(info.ActionId, info);
            }
        }
    }

    public Dictionary<string, InputInfo> GetInputInfos()
    {
        return m_actionsPressedId;
    }

    public InputInfo GetInfoByActionId(string actionId)
    {
        if (m_actionsPressedId.ContainsKey(actionId))
        {
            return m_actionsPressedId[actionId];
        }

        return new InputInfo(string.Empty, Mathf.Infinity);
    }
}

public struct InputInfo
{
    public string ActionId;
    public float Value;

    public InputInfo(string actionId, float value)
    {
        ActionId = actionId;
        Value = value;
    }
}
