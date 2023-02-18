using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatModifier : ITag
{
    public MathType ModifierType {
        get; private set;
    }
    public string InstanceId {
        get;
        private set;
    }

    [SerializeField]
    protected float m_value;

    public StatModifier(float value, MathType modifierType) {
        InstanceId = RandomIdGenerator.GetNewModifierId(); 
        m_value = value;
        ModifierType = modifierType;
    }

    public virtual float GetValue() {
        return m_value;
    }


    #region ITag Implementation
    public HashSet<Tag> Tags { get; } = new HashSet<Tag>();

    public void AddTag(Tag newTag)
    {
        if (!HasTag(newTag))
        {
            Tags.Add(newTag);
        }
    }

    public void RemoveTag(Tag removeTag)
    {
        if (HasTag(removeTag))
        {
            Tags.Remove(removeTag);
        }
    }

    public bool HasTag(Tag tag)
    {
        return Tags.Contains(tag);
    }
    #endregion
}
