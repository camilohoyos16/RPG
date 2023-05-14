using System;
using System.Collections.Generic;

public class Sword : MeleeWeapon
{
    public override void Attack(ICharacter owner, WorldState worldState) {
        // Need to use a target system to add a different ways to target for each waepon
        List<ICharacter> targets = EntitiesController.Instance.GetCharactersInRange(owner.EntityPosition, Stats.GetDynamicStat(StatsNameDictionary.RangeStatName).Value);
        foreach (ICharacter target in targets) {
            EffectsResolverComponent effectsResolverComponent = (EffectsResolverComponent)target.GetGameComponent(GameComponentDictionary.EFFECTS_RESOLVER_COMPONENT_ID);
            if(effectsResolverComponent != null) {
                foreach (PassiveEffectConfig effectConfig in EffectsContainer.GetPassiveEffectsConfig()) {
                    BasicPassiveEffect newPassiveEffect = EffectGenerator.GeneratePassiveEffect(owner, target, effectConfig);
                    effectsResolverComponent.AddPassiveEffect(newPassiveEffect);
                }

                foreach (BasicActiveEffectConfig config in EffectsContainer.GetActiveEffectsConfig()) {
                    BasicActiveEffect newActiveEffect = EffectGenerator.GenerateActiveEffect(owner, target, config);
                    effectsResolverComponent.AddActiveEffect(newActiveEffect);
                }
                break;
            }
        }
    }
}
