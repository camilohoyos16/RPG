using System.Collections.Generic;

public sealed class AttackDistanceAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    public AttackDistanceAction() : base(ActionsDictionary.ATTACK_DISTANCE_ACTION_ID) { }

    #region InputAction Implementation
    public override ActionResult ExecuteAction(ICharacter character) {
        //charcter.Attack()
        ActionResult result = new ActionResult(false, "");
        return result;
    }

    protected override void ResolveComponents() {
    }
    #endregion
}