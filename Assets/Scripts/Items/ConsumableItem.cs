using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : InventoryItem
{
    private List<ActiveEffect> m_activeEffects;
    private List<PassiveEffect> m_passiveEffects;

    public ConsumableItem(ItemConsumableDefinition itemDefinition)
       : base(itemDefinition) {
        m_activeEffects = itemDefinition.ActiveEffects;
        m_passiveEffects = itemDefinition.PassiveEffects;
    }

    #region IventoryItem Implementation
    public override void UseItem(ICharacter character) {
        EffectsResolverComponent resolverComponent = (EffectsResolverComponent)character.GetGameComponent(GameComponentDictionary.EFFECTS_RESOLVER_COMPONENT_ID);

        foreach (ActiveEffect activeEffect in m_activeEffects) {
            resolverComponent.AddActiveEffect(activeEffect);
        }

        foreach (PassiveEffect passiveEffect in m_passiveEffects) {
            resolverComponent.AddPassiveEffect(passiveEffect);
        }
    }
    #endregion
}
