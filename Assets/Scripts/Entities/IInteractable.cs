using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable : IEntity
{
    public float InteractRadius { get; }

    public void Interact(ICharacter character);
}
