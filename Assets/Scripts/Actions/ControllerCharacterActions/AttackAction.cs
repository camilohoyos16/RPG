public sealed class AttackAction : InputAction
{
    public AttackAction(string input) : base(input) {
        ActionId = ActionsDictionary.PLAYER_ATTACK_ACTION_ID;
    }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        //charcter.Attack()
    }
    #endregion
}