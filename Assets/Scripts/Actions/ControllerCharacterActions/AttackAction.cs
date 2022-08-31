public sealed class AttackAction : InputAction
{
    public AttackAction(string input) : base(input) { }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        //charcter.Move()
    }
    #endregion
}
