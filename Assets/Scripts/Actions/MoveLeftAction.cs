using System.Collections.Generic;
using UnityEngine;

public sealed class MoveLeftAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    public override string ActionId { get => ActionsDictionary.MOVE_LEFT_ACTION_ID; }

    private StatsComponent m_ownerStatsComponent;
    private PhysicsComponent m_ownerPhysicsComponent;

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character) {
        MathUtils.Vector3 newPosition = m_ownerPhysicsComponent.Rigidbody.position;
        newPosition.x -= m_ownerStatsComponent.GetDynamicStat(WorldManager.Instance.DynamicStatsDatabaseInstance.SpeedStatName.StatName).Value * Time.deltaTime;
        m_ownerPhysicsComponent.Rigidbody.position = newPosition;
        ActionResult result = new ActionResult(true, "Moved to the left");
        return result;
    }

    public override void UpdateAction()
    {
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