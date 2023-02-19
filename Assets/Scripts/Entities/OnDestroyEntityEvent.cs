using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyEntityEvent : GlobalEvent
{
    public IEntity Entity;

    public OnDestroyEntityEvent(IEntity entity)
    {
        Entity = entity;
    }
}
