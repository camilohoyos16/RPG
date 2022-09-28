public sealed class WieldMeeleWeaponAction : Action
{
    public WieldMeeleWeaponAction() : base(ActionsDictionary.WIELD_MEELE_WEAPON_ACTION_ID) { }

    #region InputAction Implementation
    public override void ExecuteAction(ICharacter character) {
        //charcter.Move()
    }

    protected override void ResolveComponents() {
    }
    #endregion
}