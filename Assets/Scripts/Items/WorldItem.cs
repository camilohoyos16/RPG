using System;
using UnityEngine;

public abstract class WorldItem : MonoBehaviour, IEntity, IInteractable
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
    public abstract void Interact(ICharacter character);
    #endregion

    #region IEntity implementation
    public abstract void InitEntity();

    public abstract void UpdateEntity(WorldState worldState);

    #endregion

}
