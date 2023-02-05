using System.Collections.Generic;
using UnityEngine;

public sealed class JumpAction : Action
{
    public override string ActionId { get => ActionsDictionary.JUMP_ACTION_ID;  }
    public override List<string> RequiredGameComponentsIds { get => new (){ GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    private StatsComponent m_statsComponent;
    private PhysicsComponent m_physicsComponent;

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character) {
        float jumpForce = m_statsComponent.GetDynamicStat(WorldManager.Instance.DynamicStatsDatabaseInstance.JumpForceStatName.StatName).Value;
        Rigidbody rigidbody = m_physicsComponent.Rigidbody;

        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        ActionResult result = new ActionResult(true, "Jumped Succesfully");
        return result;
    }

    public override void UpdateAction()
    {
    }

    protected override void ResolveComponents() {
        foreach (IGameComponent gameComponent in m_gameComponents) {
            switch (gameComponent.GameComponentId) {
                case GameComponentDictionary.STATS_COMPONENT_ID:
                    m_statsComponent = (StatsComponent)gameComponent;
                    break;

                case GameComponentDictionary.PHYSICS_COMPONENT_ID:
                    m_physicsComponent = (PhysicsComponent)gameComponent;
                    break;
                default:
                    break;
            }
        }
    }

    #endregion
}
