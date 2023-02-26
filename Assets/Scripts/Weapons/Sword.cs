using System.Collections.Generic;

public class Sword : MeleeWeapon
{
    public override void Attack(MathUtils.SVector3 position, StatsComponent ownerStats, WorldState worldState) {
        List<ICharacter> characters = EntitiesController.Instance.GetCharactersInRange(position, Stats.GetDynamicStat(StatsNameDictionary.RangeStatName).Value);
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
