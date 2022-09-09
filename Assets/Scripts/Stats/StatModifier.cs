public enum StatModifierType
{
    Add,
    Multiplier
}

public class StatModifier
{
    public StatModifierType ModifierType {
        get; private set;
    }
    public int InstanceId {
        get;
        private set;
    }

    protected float m_value;

    public StatModifier(float value, StatModifierType modifierType) {
        InstanceId = RandomIdGenerator.GetNewRandomId(); 
        m_value = value;
        ModifierType = modifierType;
    }

    public virtual float GetValue() {
        return m_value;
    }
}
