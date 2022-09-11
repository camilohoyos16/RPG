using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter : IEntity
{
    public void AddActionToCharacter(InputAction action);
    public bool HasAction(string actionId);
    public InputAction GetAction(string actionId);
    public void RemoveAction(string actionId);
}
