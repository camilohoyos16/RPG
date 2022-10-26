using System;

public abstract class ActiveEffect : Effect
{
    public Action<ActiveEffect> CallbackToController;
    public Stat ValueToApply;

    protected ActiveEffect() {

    }

    public ActiveEffect(float valueToApply) {
        ValueToApply = new Stat(valueToApply);
    }

    /// <summary>
    /// This might not be implemented on certain types of effects.
    /// Ex: Damage Over Time effects would need an implementation.
    /// </summary>
    /// <param name="gameTime"></param>
    /// <param name="deltaTime"></param>
    public abstract void TickEffect(float gameTime, float deltaTime);

    public abstract void ApplyEffect();
}