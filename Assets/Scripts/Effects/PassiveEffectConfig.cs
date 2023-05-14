using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "passive_effect_config", menuName = "Effects/New Passive Effect Config", order = 1)]
public class PassiveEffectConfig : ScriptableObject
{
    public NameScriptableObject EffectName;
    public NameScriptableObject StatToAffect;
    public float ValueToApply;
    public MathType MathType;
    public List<DynamicStatDefinition> Stats;
}
