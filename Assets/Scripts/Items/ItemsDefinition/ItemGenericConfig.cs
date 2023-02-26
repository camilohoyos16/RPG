using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenericConfig : ScriptableObject
{
    [HideInInspector]
    public string TitleOnInspector;

    public ItemIdScriptableObject ItemId;
    public string Name;
    public string Description;
    public float BasePrice;
    public byte UiMaxStack;
    public Sprite ItemSprite;
    public GameObject ItemPrefab;
}
