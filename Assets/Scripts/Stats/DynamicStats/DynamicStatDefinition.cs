using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DynamicStatDefinition
{
    [HideInInspector]
    public string TitleOnInspector;

    public StatNameScriptableObject Name;
    public float StatValue;
}
