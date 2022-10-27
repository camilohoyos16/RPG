using System;

public abstract class ActiveEffect : Effect
{
    public Action<ActiveEffect> CallbackToController;

    protected ActiveEffect() {

    }

    public string GetStatToAffectName() {
        return NameStatToAffect;
    }

    /// <summary>
    /// This might not be implemented on certain types of effects.
    /// Ex: Damage Over Time effects would need an implementation.
    /// </summary>
    /// <param name="gameTime"></param>
    /// <param name="deltaTime"></param>
    public abstract void TickEffect(float gameTime, float deltaTime);

    public abstract void ApplyEffect(float value);
}