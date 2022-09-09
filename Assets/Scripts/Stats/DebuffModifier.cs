public class DebuffModifier : StatModifier
{
    public DebuffModifier(float value, StatModifierType modifierType) : base(value, modifierType) {
    }

    #region StatModifier implementation
    public override float GetValue() {
        return m_value * -1;
    }
    #endregion
}
