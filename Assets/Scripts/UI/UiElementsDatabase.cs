using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UiElementConfig
{
    public NameScriptableObject ElementName;
    public UiElement prefab;
}

[CreateAssetMenu(fileName = "UiElementsDatabase", menuName = "Ui/new database", order = 1)]
public class UiElementsDatabase : ScriptableObject, IDatabase
{
    [SerializeField] private NameScriptableObject PlayerInventory;
    [SerializeField] private NameScriptableObject GenericContainerInventory;

    public List<UiElementConfig> UiElementConfigs;

    public void Initialize()
    {
        UiElementsDictionary.PlayerInventory = PlayerInventory.Value;
        UiElementsDictionary.GenericContainerInventory = GenericContainerInventory.Value;
        UiElementsDictionary.UiElements = new();
        foreach (UiElementConfig item in UiElementConfigs)
        {
            UiElementsDictionary.UiElements.Add(item.ElementName.Value, item.prefab);
        }
    }
}

public static class UiElementsDictionary
{
    public static string PlayerInventory;
    public static string GenericContainerInventory;

    public static Dictionary<string, UiElement> UiElements;

    public static UiElement GetElement(string key)
    {
        return UiElements[key];
    }
}
