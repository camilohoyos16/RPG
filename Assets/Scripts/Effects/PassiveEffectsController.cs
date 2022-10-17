using System.Collections.Generic;

public class PassiveEffectsController
{
    /// <summary>
    /// string: statId. Hold all effects that will trigger when this stats is "attacked"
    /// </summary>
    private Dictionary<string, List<PassiveEffect>> m_effects;

    public void Initialize() {
        if(m_effects == null) {
            m_effects = new Dictionary<string, List<PassiveEffect>>();
        }
    }

    public void AddEfect(PassiveEffect effect) {
        if (!m_effects.ContainsKey(effect.StatToAffect)) {
            m_effects.Add(effect.StatToAffect, new List<PassiveEffect>());
        } 
        m_effects[effect.StatToAffect].Add(effect);
    }

    public List<PassiveEffect> GetEffectsByStatId(string statId) {
        if (m_effects.ContainsKey(statId)) {
            return m_effects[statId];
        }

        return new List<PassiveEffect>();
    }
}
