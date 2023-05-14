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

    public void InitComponent()
    {
        m_passiveEffectsController = new PassiveEffectsController();
        m_passiveEffectsController.Initialize();
        m_activeEffectsController = new ActiveEffectsController();
    }

    public void UpdateComponent(WorldState worldState)
    {
        m_activeEffectsController.TickEffects(Time.time, Time.deltaTime);
    }

    #region PassiveEffects
    public void AddPassiveEffect(BasicPassiveEffect effect) {
        m_passiveEffectsController.AddEfect(effect);
    }
    #endregion

    #region ActiveEffects

    public void AddActiveEffect(BasicActiveEffect activeEffect) {
        activeEffect.CallbackToController = TriggerActiveEffect;
        m_activeEffectsController.AddEffect(activeEffect);
    }

    public void TriggerActiveEffect(BasicActiveEffect activeEffect) {
        float valueToApply = activeEffect.GetValueToApply();
        List<BasicPassiveEffect> passiveEffects = m_passiveEffectsController.GetEffectsByStatId(activeEffect.GetStatToAffectName());
        foreach (BasicPassiveEffect effect in passiveEffects) {
            valueToApply = effect.ApplyEffect(valueToApply); 
        }

        activeEffect.ApplyEffect(valueToApply);
    }
    #endregion
}
