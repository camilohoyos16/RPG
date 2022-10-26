public abstract class PassiveEffect : Effect
{
    public MathType MathType { get; private set; }

    private PassiveEffect() { }

    public PassiveEffect(MathType mathType) {
        MathType = mathType;
    }

    /// <summary>
    /// Parameter and return values are just being used when
    /// <see cref="PassiveEffect.MathType"/> is different from 
    /// <see cref="MathType.Neutral"/>.
    /// </summary>
    public abstract float ApplyEffect(float valueToModify);
}
