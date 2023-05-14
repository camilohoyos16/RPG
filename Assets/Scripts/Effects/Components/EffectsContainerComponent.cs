using System.Collections.Generic;
using UnityEngine;

public class EffectsContainerComponent : MonoBehaviour, IGameComponent
{
    public string GameComponentId => GameComponentDictionary.EFFECTS_APPLIER_COMPONENT_ID;

    public List<PassiveEffectConfig> PassiveEffects;
    public List<BasicActiveEffectConfig> ActiveEffects;

    private List<PassiveEffectConfig> m_passiveEffectsConfig = new List<PassiveEffectConfig>();

    private List<BasicActiveEffectConfig> m_activeEffectsConfig = new List<BasicActiveEffectConfig>();

    public void InitComponent()
    {
        ResolveEffects();
    }

    public void UpdateComponent(WorldState worldState)
    {
    }

    public List<PassiveEffectConfig> GetPassiveEffectsConfig() {
        return m_passiveEffectsConfig;
    }

    public List<BasicActiveEffectConfig> GetActiveEffectsConfig() {
        return m_activeEffectsConfig;
    }

    private void ResolveEffects() {
        foreach (PassiveEffectConfig effectConfig in PassiveEffects) {
            AddPassiveEffectConfig(effectConfig);
        }

        foreach (BasicActiveEffectConfig effectConfig in ActiveEffects)
        {
            AddActiveEffectConfig(effectConfig);
        }
    }

    #region PassiveEffects
    public void AddPassiveEffectConfig(PassiveEffectConfig config) {
        m_passiveEffectsConfig.Add(config);
    }
    #endregion

    #region ActiveEffects

    public void AddActiveEffectConfig(BasicActiveEffectConfig config) {
        m_activeEffectsConfig.Add(config);
    }
    #endregion
}
