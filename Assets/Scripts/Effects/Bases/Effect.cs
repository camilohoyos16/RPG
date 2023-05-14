using System;
using System.Collections.Generic;

#nullable enable
public abstract class Effect
{
    /// <summary>
    /// The name of the stat to deal with to be able to modify the result with all the 
    /// passive effect on the target.
    /// </summary>
    protected string NameStatToAffect { get; } = string.Empty;

    /// <summary>
    /// Effect base value
    /// </summary>
    public float ValueToApply { get; } = 0;

    protected ICharacter Attacker;
    protected ICharacter Target;

    protected Effect(ICharacter attacker, ICharacter target) {
        Attacker = attacker;
        Target = target;
    }

    /// <summary>
    /// This is a method to modify the base value before pass it to <see cref="EffectsResolverComponent"/>.
    /// Ex: Basic damage will be multiply by the strenght of the character
    /// </summary>
    /// <returns>Final value to apply</returns>
    public abstract float GetValueToApply();
}
