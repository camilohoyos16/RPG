using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputsResolver : InputActionResolver
{
    private string m_modifierId = string.Empty;

    public override void ResolveInputBeforeTriggerAction(IControllerCharacter character, WorldState worldState, string actionId)
    {
        StatsComponent stats = character.GetGameComponent(GameComponentDictionary.STATS_COMPONENT_ID) as StatsComponent;
        Stat speedStat = stats.GetDynamicStat(WorldManager.Instance.DynamicStatsDatabaseInstance.SpeedStatName.StatName);
        InputInfo inputValue = worldState.CurrentInputContext.GetInfoByActionId(actionId);
        string modifierToRemoveId = speedStat.GetModifierByTag(worldState.TagsDatabase.MoveInputSpeedModifier);
        
        if (!string.IsNullOrEmpty(modifierToRemoveId))
        {
            speedStat.RemoveModifier(modifierToRemoveId);
        }
        if (speedStat.HasModifier(m_modifierId))
        {
            speedStat.RemoveModifier(m_modifierId);
        }

        StatModifier modifier = new(inputValue.Value, MathType.Multiplicative);
        modifier.AddTag(worldState.TagsDatabase.MoveInputSpeedModifier);
        m_modifierId = speedStat.AddModifier(modifier);
    }
}
