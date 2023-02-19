using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable : IEntity
{
    public abstract float InteractRadius { get; }

    public abstract void Interact(ICharacter character);
}
