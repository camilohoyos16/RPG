using UnityEngine;

public class WorldItem : MonoBehaviour, IItem, IEntity, IInteractable
{
    /// <summary>
    /// From <see cref="IEntity"/>
    /// </summary>
    public MathUtils.Vector3 EntityPosition { get => transform.position; set => transform.position = value; }

    /// <summary>
    /// From <see cref="IItem"/>
    /// </summary>
    public ItemData ItemData { get; set; }

    public float InteractRadius { get => InteractableEntitiesDatabase.SIMPLE_INTERACTABLE_ENTITY_INTERACT_RADIUS; set { } }

    #region GenericInteractableEntity implementation

    #endregion
    public void Interact(ICharacter character) {
        if(character is Player player) {
            player.Inventory.AddItem(this);
        }
    }

    #region IEntity implementation

    public void UpdateEntity() {
        throw new System.NotImplementedException();
    }

    #endregion

    #region IItem implementation

    public void UseItem() {
        throw new System.NotImplementedException();
    }

    public void UseItem(ICharacter character) {
    }

    #endregion
}
