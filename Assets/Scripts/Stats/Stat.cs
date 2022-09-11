using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public Action<Stat> OnUpdate;

    private float m_baseValue;
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

    private void ApplyModifiers() {
        float newValue = m_baseValue;

        foreach (StatModifier modifier in m_modifiers) {
            if(modifier.ModifierType == StatModifierType.Add) {
                newValue = Math.Max(0, newValue + modifier.GetValue());
            } else {
                newValue += newValue * modifier.GetValue();
            }
        }

        m_value = newValue;
    }

    public void AddModifier(StatModifier modifier) {
        if(modifier.ModifierType == StatModifierType.Add) {
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


