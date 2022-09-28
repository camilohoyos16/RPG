
public sealed class WieldMagicWeaponAction : Action
{
    public WieldMagicWeaponAction() : base(ActionsDictionary.WIELD_MAGIC_WEAPON_ACTION_ID) { }

    #region InputAction Implementation
    public override void ExecuteAction(ICharacter character) {
        //charcter.Move()
    }
    #endregion
}
