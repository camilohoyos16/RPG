public sealed class MoveAction : Action
{
    public MoveAction() : base(ActionsDictionary.MOVE_ACTION_ID) { }

    #region InputAction Implementation
    public override void ExecuteAction(ICharacter character) {
        //charcter.Move()
    }
    #endregion
}
