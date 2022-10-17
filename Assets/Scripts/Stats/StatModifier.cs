public class StatModifier
{
    public MathType ModifierType {
        get; private set;
    }
    public int InstanceId {
        get;
        private set;
    }

    protected float m_value;

    public StatModifier(float value, MathType modifierType) {
        InstanceId = RandomIdGenerator.GetNewRandomId(); 
        m_value = value;
        ModifierType = modifierType;
    }

    public virtual float GetValue() {
        return m_value;
    }
}
