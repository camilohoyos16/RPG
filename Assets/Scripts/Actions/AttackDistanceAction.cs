using System.Collections.Generic;

public sealed class AttackDistanceAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    public override string ActionId { get => ActionsDictionary.ATTACK_DISTANCE_ACTION_ID; }

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character) {
        //charcter.Attack()
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