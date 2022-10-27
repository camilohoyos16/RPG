using System.Collections.Generic;
using UnityEngine;

public class EffectsApplierComponent : MonoBehaviour, IGameComponent
{
    public string GameComponentId => GameComponentDictionary.EFFECTS_APPLIER_COMPONENT_ID;

    private List<PassiveEffect> m_passiveEffects = new List<PassiveEffect>();

    private List<ActiveEffect> m_activeEffects = new List<ActiveEffect>();


    private void Awake() {
        GetEffects();
    }

    public List<PassiveEffect> GetPassiveEffects() {
        return m_passiveEffects;
    }

    public List<ActiveEffect> GetActiveEffects() {
        return m_activeEffects;
    }

    private void GetEffects() {
        IEffectComponent[] effectComponents = GetComponents<IEffectComponent>();

        foreach (IEffectComponent effect in effectComponents) {
            if (effect is PassiveEffectComponent passiveComponent) {
                AddPassiveEffect(passiveComponent.GenerateEffect(GetComponent<StatsComponent>()));
            } else if (effect is ActiveEffectComponent activeComponent) {
                AddActiveEffect(activeComponent.GenerateEffect(GetComponent<StatsComponent>()));

            }
        }
    }

    #region PassiveEffects
    public void AddPassiveEffect(PassiveEffect effect) {
        m_passiveEffects.Add(effect);
    }
    #endregion

    #region ActiveEffects

    public void AddActiveEffect(ActiveEffect activeEffect) {
        m_activeEffects.Add(activeEffect);
    }
    #endregion
}
