public sealed class AttackDistanceAction : InputAction
{
    public AttackDistanceAction(string input) : base(input) {
        ActionId = ActionsDictionary.PLAYER_ATTACK_DISTANCE_ACTION_ID;
    }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        //charcter.Move()
    }
    #endregion
}
