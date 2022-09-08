
public sealed class WieldMagicWeaponAction : InputAction
{
    public WieldMagicWeaponAction(string input) : base(input) {
        ActionId = ActionsDictionary.PLAYER_WIELD_MAGIC_WEAPON_ACTION_ID;
    }

    #region InputAction Implementation
    public override void ExecuteAction(IControllerCharacter character) {
        //charcter.Move()
    }
    #endregion
}
