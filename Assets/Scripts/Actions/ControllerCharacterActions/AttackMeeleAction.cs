public sealed class AttackMeeleAction : InputAction
{
    public AttackMeeleAction(string input) : base(input) { 
        ActionId = ActionsDictionary.PLAYER_ATTACK_MEELE_ACTION_ID;
    }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        //charcter.Move()
    }
    #endregion
}