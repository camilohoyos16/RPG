using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsApplierController : MonoBehaviour, IGameComponent
{
    public string GameComponentId => GameComponentDictionary.EFFECTS_APPLIER_COMPONENT_ID;

    private PassiveEffectsController m_passiveEffectsController;
    private ActiveEffectsController m_activeEffectsController;

    private void Awake() {
        GetEffects();
    }

    private void GetEffects() {
        IEffectComponent[] effectComponents = GetComponents<IEffectComponent>();

        foreach (IEffectComponent effect in effectComponents) {
            if(effect is PassiveEffectComponent passiveComponent) {
                AddPassiveEffect(passiveComponent.GenerateEffect());
            } else if (effect is ActiveEffectComponent activeComponent) {
                AddActiveEffect(activeComponent.GenerateEffect());

            }
        }
    }

    #region PassiveEffects
    public void AddPassiveEffect(PassiveEffect effect) {
        m_passiveEffectsController.AddEfect(effect);
    }
    #endregion

    #region ActiveEffects

    public void AddActiveEffect(ActiveEffect activeEffect) {
        //activeEffect.CallbackToController = TriggerActiveEffect;
        m_activeEffectsController.AddEffect(activeEffect);
        activeEffect.StartEffect();
    }
    #endregion
}