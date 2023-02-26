using System;
using UnityEngine;

public class WorldItem : MonoBehaviour, IEntity, IInteractable
{
    public ItemIdScriptableObject WorldItemId;
    public ItemCategory ItemCategory;

    /// <summary>
    /// From <see cref="IEntity"/>
    /// </summary>
    public MathUtils.SVector3 EntityPosition { get => transform.position; set => transform.position = value; }

    public float InteractRadius { get => InteractableEntitiesDatabase.SIMPLE_INTERACTABLE_ENTITY_INTERACT_RADIUS; private set { } }

    private void Awake() {
    }

    private void Start() {
        EventManager.Instance.TriggerGlobal(new OnRegisterEntityEvent(this));    
    }

    #region GenericInteractableEntity implementation
    public void Interact(ICharacter character) {
        if(character is Player player) {
            InventoryComponent inventory = (InventoryComponent)player.GetGameComponent(GameComponentDictionary.INVENTORY_COMPONENT_ID);
            inventory.AddItem(this);
        }
    }
    #endregion

    #region IEntity implementation
    public void InitEntity()
    {
    }

    public void UpdateEntity(WorldState worldState) {
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
