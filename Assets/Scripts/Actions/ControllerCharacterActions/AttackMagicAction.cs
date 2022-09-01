
public sealed class AttackMagicAction : InputAction
{
    public AttackMagicAction(string input) : base(input) {
        ActionId = ActionsDictionary.PLAYER_ATTACK_MAGIC_ACTION_ID;
    }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        //charcter.Move()
    }
    #endregion
}
