public sealed class JumpAction : Action
{
    public JumpAction() : base(ActionsDictionary.JUMP_ACTION_ID) { }

    public override string ActionId { get; protected set; }

    #region InputAction Implementation
    public override void ExecuteAction(ICharacter character) {
    }

    #endregion
}
