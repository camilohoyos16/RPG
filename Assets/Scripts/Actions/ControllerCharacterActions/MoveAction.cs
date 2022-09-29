﻿using System.Collections.Generic;

public sealed class MoveAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new (){ GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    public MoveAction() : base(ActionsDictionary.MOVE_ACTION_ID) { }

    #region InputAction Implementation
    public override void ExecuteAction(ICharacter character) {
        //charcter.Move()
    }

    protected override void ResolveComponents() {
    }
    #endregion
}
