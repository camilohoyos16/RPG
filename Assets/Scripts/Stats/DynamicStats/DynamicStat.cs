using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DynamicStat
{
    public string Name;
    public Stat Stat;

    public DynamicStat(string name, float value) {
        Name = name;
        Stat = new Stat(value);
    }
}
