public sealed class WieldDistanceWeaponAction : InputAction
{
    public WieldDistanceWeaponAction(string input) : base(input) {
        ActionId = ActionsDictionary.PLAYER_WIELD_DISTANCE_WEAPON_ACTION_ID;
    }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        //charcter.Move()
    }
    #endregion
}
