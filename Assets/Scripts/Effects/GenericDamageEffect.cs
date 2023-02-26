using System;

#nullable enable
public class GenericDamageEffect : ActiveEffect
{
    protected override string NameStatToAffect => StatsNameDictionary.HealthStatName;

    private string m_damageStatName = StatsNameDictionary.DamageStatName;
    private string m_strengthStatName = StatsNameDictionary.StrengthStatName;

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
        float finalValue = WeaponStats.GetDynamicStat(m_damageStatName).Value + (AttackerStats.GetDynamicStat(m_strengthStatName).Value / 2);
        return finalValue;
    }
}