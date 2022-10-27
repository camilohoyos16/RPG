using System;

#nullable enable
public abstract class Effect
{
    protected abstract string NameStatToAffect { get; }

    protected StatsComponent AttackerStats;
    protected StatsComponent TargetStats;
    protected StatsComponent? WeaponStats;

    protected Effect() {

    }

    public abstract float GetValueToAppy();

    public abstract void StartEffect(StatsComponent attackerStats, StatsComponent targetStats, StatsComponent? weaponStats = null);
}

[Serializable]
public class EffectConfig
{
    public StatNameScriptableObject StatToUseName;
}
