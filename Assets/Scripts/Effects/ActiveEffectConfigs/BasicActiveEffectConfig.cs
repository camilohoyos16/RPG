using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "basic_active_effect_config", menuName = "Effects/Active/Basic Active Effect Config", order = 1)]
public class BasicActiveEffectConfig : ScriptableObject
{
    public NameScriptableObject StatToAffect;
    public float ValueToApply;
}
