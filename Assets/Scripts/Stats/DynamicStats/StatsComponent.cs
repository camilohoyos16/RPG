using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : MonoBehaviour, IGameComponent
{
    [SerializeField]
    private List<DynamicStatDefinition> DynamicStatsDefinitions;
    public List<DynamicStat> DynamicStats;

    private void Awake() {
        ResolveDynamicStatsDefinition();
    }

    private void ResolveDynamicStatsDefinition() {
        DynamicStats = new ();
        foreach (DynamicStatDefinition statDefinition in DynamicStatsDefinitions) {
            DynamicStats.Add(new DynamicStat(statDefinition.Name.Value, statDefinition.StatValue));
        }
    }

    public string GameComponentId { get => GameComponentDictionary.STATS_COMPONENT_ID; }

    public void InitComponent()
    {
    }

    public void UpdateComponent(WorldState worldState)
    {
    }

    public void AddStat(params DynamicStatDefinition[] statDefinitions) {

    }

    public void RemoveStat(params DynamicStatDefinition[] statDefinitions) {

    }

    public Stat GetDynamicStat(string statName) {
        foreach (DynamicStat stat in DynamicStats) {
            if (stat.Name.Equals(statName)) {
                return stat.Stat;
            }
        }
        return null;
    }

    public bool HasDynamicStat(string statName) {
        foreach (DynamicStat stat in DynamicStats) {
            if (stat.Name.Equals(statName)) {
                return true;
            }
        }
        return false;
    }

    #region Editor
    public void OnValidate() {
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
