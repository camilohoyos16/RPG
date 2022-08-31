public sealed class JumpAction : InputAction
{
    public JumpAction(string input) : base(input) { }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        character.Jump();
    }
    #endregion
}
