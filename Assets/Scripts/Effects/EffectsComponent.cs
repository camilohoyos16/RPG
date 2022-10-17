using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MathType
{
    Additive,
    Multiplicative,
    Neutral
}


public class EffectsComponent : MonoBehaviour, IGameComponent
{
    public string GameComponentId => GameComponentDictionary.EFFECTS_COMPONENT_ID;

    private PassiveEffectsController m_passiveEffectsController;
    private ActiveEffectsController m_activeEffectsController;

    private void Update() {
        m_activeEffectsController.TickEffects(Time.time, Time.deltaTime);
    }

    #region PassiveEffects
    public void AddPassiveEffect(PassiveEffect effect) {
        m_passiveEffectsController.AddEfect(effect);
    }
    #endregion

    #region ActiveEffects

    public void AddActiveEffect(ActiveEffect activeEffect) {
        activeEffect.CallbackToController = TriggerActiveEffect;
        m_activeEffectsController.AddEffect(activeEffect);
    }

    public void TriggerActiveEffect(ActiveEffect activeEffect) {
        float valueToApply = activeEffect.ValueToApply.Value;
        List<PassiveEffect> passiveEffects = m_passiveEffectsController.GetEffectsByStatId(activeEffect.StatToAffect);
        foreach (PassiveEffect effect in passiveEffects) {
            valueToApply = effect.ActivateEffect(valueToApply); 
        }

        activeEffect.ActivateEffect(valueToApply);
    }
    #endregion
}
