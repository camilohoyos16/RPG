public class GenericDamageEffectConfig
{
    public float Value;
}

public class GenericDamageEffect : ActiveEffect
{
    public override string StatToUse => WorldManager.Instance.DynamicStatsDatabaseInstance.DamageStatName.StatName;

    public GenericDamageEffect(float valueToApply) : base (valueToApply) {

    }

    public override void StartEffect() {
        CallbackToController(this);
    }

    /// <summary>
    /// Before this being called, <see cref="EffectsResolverComponent.TriggerActiveEffect(ActiveEffect)"/>
    /// modify <see cref="ActiveEffect.ValueToApply"/> based on all the passice effects related
    /// to the stat to affect.
    /// </summary>
    public override void ApplyEffect() {
        Stat statToAffect = TargetStats.GetDynamicStat(StatToUse);
        statToAffect.ModifyBaseValue(statToAffect.Value - ValueToApply.Value);
    }


    public override void TickEffect(float gameTime, float deltaTime) {
    }
}