using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MathType
{
    Additive,
    Multiplicative,
    Neutral
}


public class EffectsResolverComponent : MonoBehaviour, IGameComponent
{
    public string GameComponentId => GameComponentDictionary.EFFECTS_RESOLVER_COMPONENT_ID;

    private PassiveEffectsController m_passiveEffectsController;
    private ActiveEffectsController m_activeEffectsController;

    private void Start() {
        m_passiveEffectsController = new PassiveEffectsController();
        m_passiveEffectsController.Initialize();
        m_activeEffectsController = new ActiveEffectsController();
    }

    public void InitComponent()
    {
    }

    public void UpdateComponent(WorldState worldState)
    {
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
        float valueToApply = activeEffect.GetValueToAppy();
        List<PassiveEffect> passiveEffects = m_passiveEffectsController.GetEffectsByStatId(activeEffect.GetStatToAffectName());
        foreach (PassiveEffect effect in passiveEffects) {
            valueToApply = effect.ApplyEffect(valueToApply); 
        }

        activeEffect.ApplyEffect(valueToApply);
    }
    #endregion
}
