using System;

#nullable enable
public class GenericDamageEffect : ActiveEffect
{
    protected override string NameStatToAffect => WorldManager.Instance.DynamicStatsDatabaseInstance.HealthStatName.StatName;

    public override void StartEffect(StatsComponent attackerStats, StatsComponent targetStats, StatsComponent? weaponStats = null) {
        AttackerStats = attackerStats;
        TargetStats = targetStats;
        WeaponStats = weaponStats;
        CallbackToController(this);
    }

    /// <summary>
    /// Before this being called, <see cref="EffectsResolverComponent.TriggerActiveEffect(ActiveEffect)"/>
    /// modify <see cref="ActiveEffect.StatToUse"/> based on all the passice effects related
    /// to the stat to affect.
    /// </summary>
    public override void ApplyEffect(float value) {
        Stat statToAffect = TargetStats.GetDynamicStat(NameStatToAffect);
        statToAffect.ModifyBaseValue(statToAffect.Value - value);
    }


    public override void TickEffect(float gameTime, float deltaTime) {
    }

    public override float GetValueToAppy() {
        string damageStatName = WorldManager.Instance.DynamicStatsDatabaseInstance.DamageStatName.StatName;
        string strengthStatName = WorldManager.Instance.DynamicStatsDatabaseInstance.StrengthStatName.StatName;
        float finalValue = WeaponStats.GetDynamicStat(damageStatName).Value + (AttackerStats.GetDynamicStat(strengthStatName).Value / 2);
        return finalValue;
    }
}