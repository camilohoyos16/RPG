
using System.Collections.Generic;

public sealed class WieldMagicWeaponAction : Action
{
    public override string ActionId { get => ActionsDictionary.WIELD_MAGIC_WEAPON_ACTION_ID;  }
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character, WorldState worldState) {
        //charcter.Move()
        ActionResult result = new ActionResult(false, "");
        return result;
    }

    public override void UpdateAction()
    {
    }

    protected override void ResolveComponents() {
    }
    #endregion
}
