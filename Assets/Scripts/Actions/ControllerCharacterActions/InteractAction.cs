using System.Collections.Generic;

public sealed class InteractAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }


    private IInteractable m_interactObject;

    public IInteractable GetInteracObject() {
        return m_interactObject;
    }

    public InteractAction(IInteractable interactObject) : base(ActionsDictionary.INTERACT_ACTION_ID) 
    {
        m_interactObject = interactObject;
    }

    #region InputAction Implementation
    public override void ExecuteAction(ICharacter character) {
        m_interactObject.Interact(character);
        //charcter.Interact()
    }

    protected override void ResolveComponents() {
    }
    #endregion
}
