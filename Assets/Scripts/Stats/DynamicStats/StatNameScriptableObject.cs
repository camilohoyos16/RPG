using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatName", menuName = "Stats/Dynamic/New StatName", order = 1)]
public class StatNameScriptableObject : ScriptableObject
{
    public string StatName;
}
