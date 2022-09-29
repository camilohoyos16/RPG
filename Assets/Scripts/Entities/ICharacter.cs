using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter : IEntity
{
    public void AddActionToCharacter(Action action);
    public bool HasAction(string actionId);
    public Action GetAction(string actionId);
    public void RemoveAction(string actionId);
    public IGameComponent GetGameComponent(string componentId);
}
