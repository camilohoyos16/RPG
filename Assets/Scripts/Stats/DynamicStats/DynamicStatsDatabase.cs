using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DynamicStatsDatabase", menuName = "Stats/Dynamic/New Database", order = 1)]
public class DynamicStatsDatabase : ScriptableObject
{
    public StatNameScriptableObject AimStatName;
    public StatNameScriptableObject DamageStatName;
    public StatNameScriptableObject ExperienceStatName;
    public StatNameScriptableObject HealthStatName;
    public StatNameScriptableObject JumpForceStatName;
    public StatNameScriptableObject ManaStatName;
    public StatNameScriptableObject MoralityStatName;
    public StatNameScriptableObject RangeStatName;
    public StatNameScriptableObject ReputationStatName;
    public StatNameScriptableObject StrengthStatName;
    public StatNameScriptableObject WeightStatName;
}
