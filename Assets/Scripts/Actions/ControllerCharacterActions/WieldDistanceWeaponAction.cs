public sealed class WieldDistanceWeaponAction : Action
{
    public WieldDistanceWeaponAction() : base(ActionsDictionary.WIELD_DISTANCE_WEAPON_ACTION_ID) { }

    #region InputAction Implementation
    public override void ExecuteAction(ICharacter character) {
        //charcter.Move()
    }

    protected override void ResolveComponents() {
    }
    #endregion
}
