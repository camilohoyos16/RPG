using System.Collections.Generic;

public class ActiveEffectsController
{
    private List<BasicActiveEffect> m_effects = new List<BasicActiveEffect>();
    
    private List<BasicActiveEffect> m_effectsToRemove = new List<BasicActiveEffect>();

    public void TickEffects(float gameTime, float deltaTime) {
        foreach (BasicActiveEffect effect in m_effects) {
            effect.TickEffect(gameTime, deltaTime);

            if(effect.HasStarted && !effect.IsRunning)
            {
                m_effectsToRemove.Add(effect);
            }
        }

        foreach (BasicActiveEffect effectToRemove in m_effectsToRemove)
        {
            RemoveEffect(effectToRemove);
        }

        m_effectsToRemove.Clear();
    }

    public void AddEffect(BasicActiveEffect effect) {
        m_effects.Add(effect);
    }

    public void RemoveEffect(BasicActiveEffect effect) {
        m_effects.Remove(effect);
    }
}
