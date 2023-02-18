using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericInteractableEntity : MonoBehaviour, IInteractable
{
    /// <summary>
    /// From <see cref="IInteractable"/>
    /// </summary>
    public abstract float InteractRadius { get; set; }

    /// <summary>
    /// From <see cref="IEntity"/>
    /// </summary>
    public MathUtils.SVector3 EntityPosition { get => transform.position; set => transform.position = value; }

    private void Start() {
        EventManager.Instance.TriggerGlobal(new OnRegisterEntityEvent(this));
    }

    #region IInteractable implementation
    public abstract void Interact(ICharacter character);
    #endregion

    #region IEntity implementation
    public void UpdateEntity(WorldState worldState) {
    }
    #endregion
}