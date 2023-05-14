using System;

#nullable enable
public class GenericWeaponDamageEffect : BasicActiveEffect
{
    private string m_damageStatName = StatsNameDictionary.DamageStatName;
    private string m_strengthStatName = StatsNameDictionary.StrengthStatName;
    protected WieldItem? Weapon;

    public GenericWeaponDamageEffect(ICharacter attacker, ICharacter target, BasicActiveEffectConfig activeEffectConfig)
        : base(attacker, target, activeEffectConfig)
    {
        //Weapon = weapon;
    }


    /// <summary>
    /// Before this being called, <see cref="EffectsResolverComponent.TriggerActiveEffect(BasicActiveEffect)"/>
    /// modify <see cref="BasicActiveEffect.StatToUse"/> based on all the passive effects related
    /// to the stat to affect.
    /// </summary>
    public override void ApplyEffect(float value) {
        StatsComponent? statsComponent = Target.GetGameComponent(GameComponentDictionary.STATS_COMPONENT_ID) as StatsComponent;
        if(statsComponent == null)
        {
            return;
        }
        Stat statToAffect = statsComponent.GetDynamicStat(NameStatToAffect);
        statToAffect.ModifyBaseValue(statToAffect.Value - value);
    }


    public override void TickEffect(float gameTime, float deltaTime) {
    }

    public override float GetValueToApply() {
        float finalValue = 0;// Weapon.GetDynamicStat(m_damageStatName).Value + (Attacker.GetDynamicStat(m_strengthStatName).Value / 2);
        return finalValue;
    }
}