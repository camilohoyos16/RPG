using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DynamicStatsDatabase", menuName = "Stats/Dynamic/New Database", order = 1)]
public class DynamicStatsDatabase : ScriptableObject, IDatabase
{
    public string DatabaseId => DatabaseDictionary.DYNAMIC_STATS_DATABASE_ID;

    [SerializeField] private StatNameScriptableObject AimStatNameConfig;
    [SerializeField] private StatNameScriptableObject DamageStatNameConfig;
    [SerializeField] private StatNameScriptableObject ExperienceStatNameConfig;
    [SerializeField] private StatNameScriptableObject HealthStatNameConfig;
    [SerializeField] private StatNameScriptableObject JumpForceStatNameConfig;
    [SerializeField] private StatNameScriptableObject ManaStatNameConfig;
    [SerializeField] private StatNameScriptableObject MoralityStatNameConfig;
    [SerializeField] private StatNameScriptableObject RangeStatNameConfig;
    [SerializeField] private StatNameScriptableObject ReputationStatNameConfig;
    [SerializeField] private StatNameScriptableObject StrengthStatNameConfig;
    [SerializeField] private StatNameScriptableObject SpeedStatNameConfig;
    [SerializeField] private StatNameScriptableObject WeightStatNameConfig;

    public void Initialize()
    {
        StatsNameDictionary.AimStatName = AimStatNameConfig.StatName;
        StatsNameDictionary.DamageStatName = DamageStatNameConfig.StatName;
        StatsNameDictionary.ExperienceStatName = ExperienceStatNameConfig.StatName;
        StatsNameDictionary.HealthStatName = HealthStatNameConfig.StatName;
        StatsNameDictionary.JumpForceStatName = JumpForceStatNameConfig.StatName;
        StatsNameDictionary.ManaStatName = ManaStatNameConfig.StatName;
        StatsNameDictionary.MoralityStatName = MoralityStatNameConfig.StatName;
        StatsNameDictionary.RangeStatName = RangeStatNameConfig.StatName;
        StatsNameDictionary.ReputationStatName = ReputationStatNameConfig.StatName;
        StatsNameDictionary.StrengthStatName = StrengthStatNameConfig.StatName;
        StatsNameDictionary.SpeedStatName = SpeedStatNameConfig.StatName;
        StatsNameDictionary.WeightStatName = WeightStatNameConfig.StatName;
    }
}
