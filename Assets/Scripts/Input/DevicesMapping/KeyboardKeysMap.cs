using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KeyConfig
{
    [HideInInspector]
    public string TitleOnInspector;

    public string Name;
    public string InputSystemCode;
}

[CreateAssetMenu(fileName = "KeyboardKeysMap", menuName = "Input/New Keyboard Keys Map", order = 1)]
public class KeyboardKeysMap : ScriptableObject
{
    public List<KeyConfig> KeysConfig;

    private void OnValidate()
    {
        foreach (KeyConfig key in KeysConfig)
        {
            if(key is not null)
            {
                key.TitleOnInspector = string.Concat(key.Name, "-", key.InputSystemCode);
            }
        }
    }
}
