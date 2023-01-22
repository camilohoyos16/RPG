using System.Collections.Generic;

public sealed class WieldDistanceWeaponAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }
    public override string ActionId { get => ActionsDictionary.WIELD_DISTANCE_WEAPON_ACTION_ID; }

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character) {
        character.AddActionToCharacter(new AttackDistanceAction());
        character.AddActionToCharacter(new WieldMeeleWeaponAction());
        character.RemoveAction(ActionId);
        ActionResult result = new ActionResult(true, "Wielded Distance Weapon");
        return result;
    }

    protected override void ResolveComponents() {
    }
    #endregion
}
