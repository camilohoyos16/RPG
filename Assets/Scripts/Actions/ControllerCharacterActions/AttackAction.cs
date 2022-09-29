using System.Collections.Generic;

public sealed class AttackAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    public AttackAction() : base(ActionsDictionary.ATTACK_ACTION_ID) { }

    #region InputAction Implementation
    public override void ExecuteAction(ICharacter character) {
        //charcter.Attack()
    }

    protected override void ResolveComponents() {
    }
    #endregion
}