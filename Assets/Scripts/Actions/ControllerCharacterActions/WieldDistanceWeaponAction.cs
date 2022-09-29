using System.Collections.Generic;

public sealed class WieldDistanceWeaponAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    public WieldDistanceWeaponAction() : base(ActionsDictionary.WIELD_DISTANCE_WEAPON_ACTION_ID) { }

    #region InputAction Implementation
    public override void ExecuteAction(ICharacter character) {
        //charcter.Move()
    }

    protected override void ResolveComponents() {
    }
    #endregion
}
