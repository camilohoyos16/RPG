using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericInteractableEntity : MonoBehaviour, IInteractable
{
    public abstract float InteractRadius { get; set; }
    public MathUtils.Vector3 EntityPosition { get => transform.position; set => transform.position = value; }

    private void Start() {
        EventManager.Instance.TriggerGlobal(new OnRegisterEntityEvent(this));
    }

    public abstract void Interact(ICharacter character);

    public void UpdateEntity() {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}