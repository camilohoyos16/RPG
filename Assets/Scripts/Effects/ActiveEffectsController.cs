using System.Collections.Generic;

public class ActiveEffectsController
{
    private List<ActiveEffect> m_effects = new List<ActiveEffect>();

    public void TickEffects(float gameTime, float deltaTime) {
        foreach (ActiveEffect effect in m_effects) {
            effect.TickEffect(gameTime, deltaTime);
        } 
    }

    public void AddEffect(ActiveEffect effect) {
        m_effects.Add(effect);
    }

    public void RemoveEffect(ActiveEffect effect) {
        m_effects.Remove(effect);
    }
}
