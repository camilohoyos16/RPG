public sealed class JumpAction : InputAction
{
    public JumpAction(string input) : base(input) {
        ActionId = ActionsDictionary.PLAYER_JUMP_ACTION_ID;
    }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        character.Jump();
    }
    #endregion
}
