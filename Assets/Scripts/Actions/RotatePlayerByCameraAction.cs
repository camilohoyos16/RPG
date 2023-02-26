using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerByCameraAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.PHYSICS_COMPONENT_ID }; }
    public override string ActionId { get => ActionsDictionary.ROTATE_PLAYER_BY_CAMERA_ACTION_ID; }

    private StatsComponent m_ownerStatsComponent;
    private PhysicsComponent m_ownerPhysicsComponent;

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character, WorldState worldState)
    {
        MathUtils.SVector3 newPosition = m_ownerPhysicsComponent.Rigidbody.position;
        newPosition.x += m_ownerStatsComponent.GetDynamicStat(StatsNameDictionary.SpeedStatName).Value * Time.deltaTime;
        //m_ownerPhysicsComponent.Rigidbody. = newPosition;
        ActionResult result = new ActionResult(true, "Moved to the right");
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
