using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    public virtual string ActionId { get; protected set; }

    public abstract void ExecuteAction(ICharacter character);

    public Action(string actionId) {
        ActionId = actionId;
    }
}
