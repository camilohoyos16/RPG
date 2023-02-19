using System.Collections.Generic;

public sealed class WieldMeeleWeaponAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    public override string ActionId { get => ActionsDictionary.WIELD_MEELE_WEAPON_ACTION_ID; }

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character, WorldState worldState) {
        character.QueueActionToAdd(new AttackMeleeAction());
        character.QueueActionToAdd(new WieldDistanceWeaponAction());
        character.QueueActionToRemove(ActionId);
        ActionResult result = new ActionResult(true, "Wielded Melee Weapon");
        return result;
    }

    public override void UpdateAction()
    {
    }

    protected override void ResolveComponents() {
    }
    #endregion
}