public sealed class MoveAction : InputAction
{
    public MoveAction(string input) : base(input) { }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        //charcter.Move()
    }
    #endregion
}
