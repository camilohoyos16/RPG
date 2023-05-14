public class TickActiveEffect : BasicActiveEffect
{
    private int m_ticks;
    private int m_cadence;

    public TickActiveEffect(
        ICharacter attacker, 
        ICharacter target, 
        BasicActiveEffectConfig activeEffectConfig,
        int ticks,
        int cadence)
        : base(attacker, target, activeEffectConfig) 
    {
        m_ticks = ticks;
        m_cadence = cadence;
    }

    public override void TickEffect(float gameTime, float deltaTime)
    {

    }


    public override void ApplyEffect(float processedValue)
    {
        throw new System.NotImplementedException();
    }

    
    public override float GetValueToApply()
    {
        return ValueToApply;
    }

}