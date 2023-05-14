using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : InventoryItem
{
    private List<BasicActiveEffect> m_activeEffects;
    private List<BasicPassiveEffect> m_passiveEffects;

    public ConsumableItem(ItemConsumableDefinition itemDefinition)
       : base(itemDefinition) {
        m_activeEffects = itemDefinition.ActiveEffects;
        m_passiveEffects = itemDefinition.PassiveEffects;
    }

    #region IventoryItem Implementation
    public override void UseItem(ICharacter character) {
        EffectsResolverComponent resolverComponent = (EffectsResolverComponent)character.GetGameComponent(GameComponentDictionary.EFFECTS_RESOLVER_COMPONENT_ID);

        foreach (BasicActiveEffect activeEffect in m_activeEffects) {
            resolverComponent.AddActiveEffect(activeEffect);
        }

        foreach (BasicPassiveEffect passiveEffect in m_passiveEffects) {
            resolverComponent.AddPassiveEffect(passiveEffect);
        }
    }
    #endregion
}
