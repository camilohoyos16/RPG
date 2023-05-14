using System.Collections.Generic;

public class PassiveEffectsController
{
    /// <summary>
    /// string: statId. Hold all effects that will trigger when this stats is "attacked"
    /// </summary>
    private Dictionary<string, List<BasicPassiveEffect>> m_effects;

    public void Initialize() {
        if(m_effects == null) {
            m_effects = new Dictionary<string, List<BasicPassiveEffect>>();
        }
    }

    public void AddEfect(BasicPassiveEffect effect) {
        if (!m_effects.ContainsKey(effect.GetStatNameToAffect())) {
            m_effects.Add(effect.GetStatNameToAffect(), new List<BasicPassiveEffect>());
        } 
        m_effects[effect.GetStatNameToAffect()].Add(effect);
    }

    public List<BasicPassiveEffect> GetEffectsByStatId(string statId) {
        if (m_effects.ContainsKey(statId)) {
            return m_effects[statId];
        }

        return new List<BasicPassiveEffect>();
    }
}
