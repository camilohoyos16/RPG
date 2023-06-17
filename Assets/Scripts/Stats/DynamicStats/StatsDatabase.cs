using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DynamicStatsDatabase", menuName = "Stats/Dynamic/New Database", order = 1)]
public class StatsDatabase : ScriptableObject, IDatabase
{
    [SerializeField] private NameScriptableObject AimStatNameConfig;
    [SerializeField] private NameScriptableObject CadenceStatNameConfig;
    [SerializeField] private NameScriptableObject DamageStatNameConfig;
    [SerializeField] private NameScriptableObject ExperienceStatNameConfig;
    [SerializeField] private NameScriptableObject HealthStatNameConfig;
    [SerializeField] private NameScriptableObject JumpForceStatNameConfig;
    [SerializeField] private NameScriptableObject ManaStatNameConfig;
    [SerializeField] private NameScriptableObject MoralityStatNameConfig;
    [SerializeField] private NameScriptableObject RangeStatNameConfig;
    [SerializeField] private NameScriptableObject ReputationStatNameConfig;
    [SerializeField] private NameScriptableObject StrengthStatNameConfig;
    [SerializeField] private NameScriptableObject SpeedStatNameConfig;
    [SerializeField] private NameScriptableObject TickStatNameConfig;
    [SerializeField] private NameScriptableObject WeightStatNameConfig;

    public void Initialize()
    {
        StatsNameDictionary.AimStatName = AimStatNameConfig.Value;
        StatsNameDictionary.CadenceStatName = CadenceStatNameConfig.Value;
        StatsNameDictionary.DamageStatName = DamageStatNameConfig.Value;
        StatsNameDictionary.ExperienceStatName = ExperienceStatNameConfig.Value;
        StatsNameDictionary.HealthStatName = HealthStatNameConfig.Value;
        StatsNameDictionary.JumpForceStatName = JumpForceStatNameConfig.Value;
        StatsNameDictionary.ManaStatName = ManaStatNameConfig.Value;
        StatsNameDictionary.MoralityStatName = MoralityStatNameConfig.Value;
        StatsNameDictionary.RangeStatName = RangeStatNameConfig.Value;
        StatsNameDictionary.ReputationStatName = ReputationStatNameConfig.Value;
        StatsNameDictionary.StrengthStatName = StrengthStatNameConfig.Value;
        StatsNameDictionary.SpeedStatName = SpeedStatNameConfig.Value;
        StatsNameDictionary.TicksStatName = TickStatNameConfig.Value;
        StatsNameDictionary.WeightStatName = WeightStatNameConfig.Value;
    }
}