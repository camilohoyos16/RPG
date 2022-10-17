using System.Collections.Generic;

public sealed class WieldMeeleWeaponAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    public WieldMeeleWeaponAction() : base(ActionsDictionary.WIELD_MEELE_WEAPON_ACTION_ID) { }

    #region InputAction Implementation
    public override ActionResult ExecuteAction(ICharacter character) {
        character.AddActionToCharacter(new AttackMeleeAction());
        character.AddActionToCharacter(new WieldDistanceWeaponAction());
        character.RemoveAction(ActionId);
        ActionResult result = new ActionResult(true, "Wielded Melee Weapon");
        return result;
    }

    protected override void ResolveComponents() {
    }
    #endregion
}