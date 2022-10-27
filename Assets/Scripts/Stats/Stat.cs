using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDynamicStats
{
    public void AddStats(params Stat[] stats);
    public void RemoveStats(params string[] stats);
    public bool HasStat(string statId);
    public Stat GetStat(string statId);
}

[Serializable]
public class Stat
{
    public Action<Stat> OnUpdate;

    [SerializeField]
    private float m_baseValue;
    [SerializeField]
    private float m_value;

    private List<StatModifier> m_modifiers;

    public Stat(float value) {
        m_baseValue = value;
        m_modifiers = new List<StatModifier>();
    }

    public float Value {
        get {
            ApplyModifiers();
            return m_value;
        }
    }

    public void ModifyBaseValue(float newValue) {
        m_baseValue = newValue;
    }

    private void ApplyModifiers() {
        float newValue = m_baseValue;

        foreach (StatModifier modifier in m_modifiers) {
            if(modifier.ModifierType == MathType.Additive) {
                newValue = Math.Max(0, newValue + modifier.GetValue());
            } else {
                newValue += newValue * modifier.GetValue();
            }
        }

        m_value = newValue;
    }

    public void AddModifier(StatModifier modifier) {
        if(modifier.ModifierType == MathType.Additive) {
            m_modifiers.Insert(0, modifier);
        } else {
            m_modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(int instanceId) {
        int modifierIndex = -1;
        int modifiersCount = m_modifiers.Count;
        for (int i = 0; i < modifiersCount; i++) {
            if(m_modifiers[i].InstanceId == instanceId) {
                modifierIndex = i;
                break;
            }
        }
        if(modifierIndex != -1) {
            m_modifiers.RemoveAt(modifierIndex);
        }
    }
}


