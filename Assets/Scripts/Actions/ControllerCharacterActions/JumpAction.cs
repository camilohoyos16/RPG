using System.Collections.Generic;
using UnityEngine;

public sealed class JumpAction : Action
{
    public JumpAction() : base(ActionsDictionary.JUMP_ACTION_ID) { }

    public override string ActionId { get; protected set; }
    public override List<string> RequiredGameComponentsIds { get => new (){ GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    private StatsComponent m_statsComponent;
    private PhysicsComponent m_physicsComponent;

    #region InputAction Implementation
    public override void ExecuteAction(ICharacter character) {
        float jumpForce = m_statsComponent.GetDynamicStat(WorldManager.Instance.DynamicStatsDatabaseInstance.JumpForceStatName.StatName).Value;
        Rigidbody rigidbody = m_physicsComponent.Rigidbody;

        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
