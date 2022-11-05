using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenericDefinition : ScriptableObject
{
    [HideInInspector]
    public string TitleOnInspector;

    public ItemIdScriptableObject ItemId;
    public string Name;
    public string Description;
    public float BasePrice;
    public int MaxStack;
}
