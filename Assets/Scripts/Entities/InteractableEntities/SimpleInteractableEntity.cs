using UnityEngine;

public class SimpleInteractableEntity : GenericInteractableEntity
{
    public override float InteractRadius { get => InteractableEntitiesDatabase.SIMPLE_INTERACTABLE_ENTITY_INTERACT_RADIUS; set { } }

    public override void Interact(ICharacter character) {
        Debug.LogError("Interacting");
    }
}
