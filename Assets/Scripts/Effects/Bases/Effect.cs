using System;
using UnityEngine;

public abstract class Effect
{
    public abstract string StatToUse { get; }

    protected StatsComponent AttackerStats;
    protected StatsComponent TargetStats;

    public abstract void StartEffect();
}

[Serializable]
public class EffectConfig
{
    public StatNameScriptableObject StatToUseName;
}

public class EffectApplierComponents : MonoBehaviour
{

}
