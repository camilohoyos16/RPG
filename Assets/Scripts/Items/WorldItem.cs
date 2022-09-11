using System;
using UnityEngine;

[Serializable]
public class ItemConfig
{
    public bool IsStackable;
    public float MaxStack;
    public float Quantity;
}

public class WorldItem : MonoBehaviour, IItem, IEntity, IInteractable
{
    public ItemConfig ItemConfig;

    /// <summary>
    /// From <see cref="IEntity"/>
    /// </summary>
    public MathUtils.Vector3 EntityPosition { get => transform.position; set => transform.position = value; }

    /// <summary>
    /// From <see cref="IItem"/>
    /// </summary>
    public ItemData ItemData { get; set; }

    public float InteractRadius { get => InteractableEntitiesDatabase.SIMPLE_INTERACTABLE_ENTITY_INTERACT_RADIUS; set { } }

    private void Awake() {
        ItemData = new ItemData(ItemConfig);
    }

    private void Start() {
        EventManager.Instance.TriggerGlobal(new OnRegisterEntityEvent(this));    
    }

    #region GenericInteractableEntity implementation

    #endregion
    public void Interact(ICharacter character) {
        if(character is Player player) {
            player.Inventory.AddItem(this);
        }
    }

    #region IEntity implementation

    public void UpdateEntity() {
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
