using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardInputResolver : InputActionResolver
{
    public override void ResolveInputBeforeTriggerAction(IControllerCharacter character, InputContext context, string actionId)
    {
        StatsComponent stats = character.GetGameComponent(GameComponentDictionary.STATS_COMPONENT_ID) as StatsComponent;
        Stat speedStat = stats.GetDynamicStat(WorldManager.Instance.DynamicStatsDatabaseInstance.SpeedStatName.StatName);
        InputInfo inputValue = context.GetInfoByActionId(actionId);
        speedStat.AddModifier(new(inputValue.Value, MathType.Multiplicative));
    }
}
