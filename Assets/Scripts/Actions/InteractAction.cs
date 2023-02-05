using System.Collections.Generic;

public sealed class InteractAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }
    public override string ActionId { get => ActionsDictionary.INTERACT_ACTION_ID; }


    private IInteractable m_interactObject;

    public IInteractable GetInteracObject() {
        return m_interactObject;
    }

    public InteractAction(IInteractable interactObject)
    {
        m_interactObject = interactObject;
    }

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character) {
        m_interactObject.Interact(character);

        ActionResult result = new ActionResult(true, "Interacted with object");
        return result;
    }

    public override void UpdateAction()
    {
    }

    protected override void ResolveComponents() {
    }
    #endregion
}
