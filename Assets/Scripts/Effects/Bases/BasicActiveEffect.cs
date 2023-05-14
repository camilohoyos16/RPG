using System;
using System.Collections.Generic;

public class BasicActiveEffect : Effect
{
    public Action<BasicActiveEffect> CallbackToController;

    public bool HasStarted;
    public bool IsRunning;

    private BasicActiveEffectConfig m_effectConfig;

    public BasicActiveEffect(ICharacter attacker, ICharacter target, BasicActiveEffectConfig effectConfig)
        : base(attacker, target)
    {
        m_effectConfig = effectConfig;
    }

    public string GetStatToAffectName() {
        return NameStatToAffect;
    }

    /// <summary>
    /// This might not be implemented on certain types of effects.
    /// Ex: Damage Over Time effects would need an implementation.
    /// </summary>
    /// <param name="gameTime"></param>
    /// <param name="deltaTime"></param>
    public virtual void TickEffect(float gameTime, float deltaTime)
    {

    }

    /// <summary>
    /// Base value need to processed through all the passive effect on the target.
    /// </summary>
    /// <param name="processedValue">Result of the process explained above</param>
    public virtual void ApplyEffect(float processedValue)
    {
    }

    public override float GetValueToApply()
    {
        return ValueToApply;
    }
}
