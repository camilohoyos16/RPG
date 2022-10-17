public abstract class PassiveEffect : Effect
{
    public MathType MathType { get; private set; }

    private PassiveEffect() { }

    public PassiveEffect(MathType mathType) {
        MathType = mathType;
    }
}
