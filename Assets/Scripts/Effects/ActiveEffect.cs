using System;

public abstract class ActiveEffect : Effect
{
    public Action<ActiveEffect> CallbackToController;
    public Stat ValueToApply;

    private ActiveEffect() {

    }

    public ActiveEffect(float valueToApply) {
        ValueToApply = new Stat(valueToApply);
    }

    public abstract void TickEffect(float gameTime, float deltaTime);

}