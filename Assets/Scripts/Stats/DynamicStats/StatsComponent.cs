using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : MonoBehaviour, IGameComponent
{
    public string GameComponentId { get => GameComponentDictionary.STATS_COMPONENT_ID; }

    [SerializeField]
    private List<DynamicStatDefinition> DynamicStatsDefinitions;
    public Dictionary<string, Stat> DynamicStats;

    private void ResolveDynamicStatsDefinition() {
        DynamicStats = new ();
        foreach (DynamicStatDefinition statDefinition in DynamicStatsDefinitions) {
            AddStat(new DynamicStat(statDefinition.Name.Value, statDefinition.StatValue));
        }
    }

    public void InitComponent()
    {
        ResolveDynamicStatsDefinition();
    }

    public void UpdateComponent(WorldState worldState)
    {
    }

    public void AddStat(params DynamicStat[] statDefinitions) {
        foreach (DynamicStat stat in statDefinitions)
        {
            if (!DynamicStats.ContainsKey(stat.Name))
            {
                DynamicStats.Add(stat.Name, stat.Stat);
            }
        }
    }

    public void RemoveStat(params DynamicStat[] statDefinitions) {
        foreach (DynamicStat stat in statDefinitions)
        {
            if (DynamicStats.ContainsKey(stat.Name))
            {
                DynamicStats.Remove(stat.Name);
            }
        }
    }

    public Stat GetDynamicStat(string statName) {
        if (DynamicStats.ContainsKey(statName))
        {
            return DynamicStats[statName];
        }
        return null;
    }

    public bool HasDynamicStat(string statName) {
        if (DynamicStats.ContainsKey(statName))
        {
            return true;
        }
        return false;
    }

    #region Editor
    public void OnValidate() {
        if(DynamicStatsDefinitions == null){
            return;
        }

        foreach (DynamicStatDefinition statDefinition in DynamicStatsDefinitions) {
            if(statDefinition is null) {
                continue;
            }

            if(statDefinition.Name != null) {
                statDefinition.TitleOnInspector = string.Concat("Name: ", statDefinition.Name.Value, " - Value: ", statDefinition.StatValue);
            } else {
                statDefinition.TitleOnInspector = "----------------------------";
            }
        }
    }
    #endregion
}
