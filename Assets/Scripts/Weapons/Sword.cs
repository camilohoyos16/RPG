using System.Collections.Generic;

public class Sword : MeleeWeapon
{
    public override void Attack(MathUtils.Vector3 position, StatsComponent ownerStats) {
        List<ICharacter> characters = EntitiesController.Instance.GetCharactersInRange(position, Stats.GetDynamicStat(WorldManager.Instance.DynamicStatsDatabaseInstance.RangeStatName.StatName).Value);
        foreach (ICharacter character in characters) {
            EffectsResolverComponent effectsResolverComponent = (EffectsResolverComponent)character.GetGameComponent(GameComponentDictionary.EFFECTS_RESOLVER_COMPONENT_ID);
            if(effectsResolverComponent != null) {
                foreach (var item in EffectApplier.GetPassiveEffects()) {
                    effectsResolverComponent.AddPassiveEffect(item);
                }

                foreach (var item in EffectApplier.GetActiveEffects()) {
                    effectsResolverComponent.AddActiveEffect(item);
                    item.StartEffect(ownerStats, (StatsComponent)character.GetGameComponent(GameComponentDictionary.STATS_COMPONENT_ID), Stats);
                }
                break;
            }
        }
    }
}
