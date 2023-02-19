using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter : IEntity , IInteractable
{
    public void QueueActionToAdd(Action action);
    public bool HasAction(string actionId);
    public Action? GetAction(string actionId);
    public void QueueActionToRemove(string actionId);
    public IGameComponent GetGameComponent(string componentId);
}
