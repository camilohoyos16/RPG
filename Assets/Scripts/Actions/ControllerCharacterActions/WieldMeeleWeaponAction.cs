public sealed class WieldMeeleWeaponAction : InputAction
{
    public WieldMeeleWeaponAction(string input) : base(input) { 
        ActionId = ActionsDictionary.PLAYER_WIELD_MEELE_WEAPON_ACTION_ID;
    }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        //charcter.Move()
    }
    #endregion
}