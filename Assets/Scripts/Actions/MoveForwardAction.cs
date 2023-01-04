using System.Collections.Generic;

public sealed class MoveForwardAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    public MoveForwardAction() : base(ActionsDictionary.MOVE_FORWARD_ACTION_ID) { }

    private StatsComponent m_ownerStatsComponent;
    private PhysicsComponent m_ownerPhysicsComponent;

    #region InputAction Implementation
    public override ActionResult ExecuteAction(ICharacter character) {
        MathUtils.Vector3 newPosition = m_ownerPhysicsComponent.Rigidbody.position;
        newPosition.z += m_ownerStatsComponent.GetDynamicStat(WorldManager.Instance.DynamicStatsDatabaseInstance.SpeedStatName.StatName).Value;
        m_ownerPhysicsComponent.Rigidbody.position = newPosition;
        ActionResult result = new ActionResult(true, "Moved to forward");
        return result;
    }

    protected override void ResolveComponents() {
        foreach (IGameComponent gameComponent in m_gameComponents) {
            switch (gameComponent.GameComponentId) {
                case GameComponentDictionary.STATS_COMPONENT_ID:
                    m_ownerStatsComponent = (StatsComponent)gameComponent;
                    break;
                case GameComponentDictionary.PHYSICS_COMPONENT_ID:
                    m_ownerPhysicsComponent = (PhysicsComponent)gameComponent;
                    break;
                default:
                    break;
            }
        }
    }
    #endregion
}
