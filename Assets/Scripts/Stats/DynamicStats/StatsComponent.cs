using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : MonoBehaviour
{
    public List<DynamicStatDefinition> DynamicStatsDefinitions;
    private List<DynamicStat> DynamicStats;

    public void AddStat(params DynamicStatDefinition[] statDefinitions) {

    }

    public void RemoveStat(params DynamicStatDefinition[] statDefinitions) {

    }

    public Stat GetDynamicStat(string statName) {
        return null;
    }

    public bool HasDynamicStat(string statName) {
        return false;
    }
}
