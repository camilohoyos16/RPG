public class OnRegisterEntityEvent : GlobalEvent
{
    public IEntity Entity;

    public OnRegisterEntityEvent(IEntity entity) {
        Entity = entity;
    }
}
