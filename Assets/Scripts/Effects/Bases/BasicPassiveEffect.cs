public class BasicPassiveEffect : Effect
{
    public MathType MathType { get; private set; }
    private PassiveEffectConfig m_passiveEffectConfig;

    public string GetStatNameToAffect() {
        return NameStatToAffect;
    }

    public override float GetValueToApply()
    {
        throw new System.NotImplementedException();
    }

    public BasicPassiveEffect(ICharacter attacker, ICharacter target, PassiveEffectConfig passiveEffectConfig) : 
        base(attacker, target) {
        MathType = passiveEffectConfig.MathType;
        m_passiveEffectConfig = passiveEffectConfig;
    }

    /// <summary>
    /// Parameter and return values are just being used when
    /// <see cref="BasicPassiveEffect.MathType"/> is different from 
    /// <see cref="MathType.Neutral"/>.
    /// </summary>
    public float ApplyEffect(float valueToModify)
    {
        return valueToModify;
    }
}