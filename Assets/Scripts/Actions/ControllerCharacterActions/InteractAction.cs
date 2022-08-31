public sealed class InteractAction : InputAction
{
    public InteractAction(string input) : base(input) { }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        //charcter.Interact()
    }
    #endregion
}
