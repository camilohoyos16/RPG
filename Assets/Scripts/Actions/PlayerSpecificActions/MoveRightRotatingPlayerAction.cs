using System.Collections.Generic;
using UnityEngine;

public class MoveRightRotatingPlayerAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    public override string ActionId { get => ActionsDictionary.MOVE_RIGHT_ACTION_ID; }

    private StatsComponent m_ownerStatsComponent;
    private PhysicsComponent m_ownerPhysicsComponent;

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character, WorldState worldState)
    {
        MathUtils.LookAtToSameDirection(m_ownerPhysicsComponent.Rigidbody.transform, worldState.CameraControllerState.CameraTransform);

        MathUtils.SVector3 lastPosition = m_ownerPhysicsComponent.Rigidbody.position;
        MathUtils.SVector3 sumPosition =
            m_ownerPhysicsComponent.Rigidbody.transform.right *
            m_ownerStatsComponent.GetDynamicStat(WorldManager.Instance.DynamicStatsDatabaseInstance.SpeedStatName.StatName).Value *
            worldState.DeltaTime;
        m_ownerPhysicsComponent.Rigidbody.position = lastPosition + sumPosition;
        ActionResult result = new ActionResult(true, "Moved to forward");
        return result;
    }

    public override void UpdateAction()
    {
    }

    protected override void ResolveComponents()
    {
        foreach (IGameComponent gameComponent in m_gameComponents)
        {
            switch (gameComponent.GameComponentId)
            {
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
