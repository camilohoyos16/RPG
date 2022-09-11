public sealed class InteractAction : InputAction
{
    private IInteractable m_interactObject;

    public IInteractable GetInteracObject() {
        return m_interactObject;
    }

    public InteractAction(string input, IInteractable interactObject) : base(input) 
    {
        m_interactObject = interactObject;
        ActionId = ActionsDictionary.PLAYER_INTERACT_ACTION_ID;
    }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        m_interactObject.Interact(character);
        //charcter.Interact()
    }
    #endregion
}
