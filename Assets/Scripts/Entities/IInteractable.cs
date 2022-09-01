using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable : IEntity
{
    public float InteractRadius { get; set; }

    public void Interact(ICharacter character);
}
