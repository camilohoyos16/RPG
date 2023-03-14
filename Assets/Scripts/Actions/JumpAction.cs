using System.Collections.Generic;
using UnityEngine;

public sealed class PauseGameAction : Action
{
    public override string ActionId { get => ActionsDictionary.PAUSE_GAME_ACTION_ID; }
    public override List<string> RequiredGameComponentsIds { get => new(); }
    public override float ConsecutiveExecutionsTime { get => ActionsDictionary.INTERACT_ACTION_CONSECUTIVE_EXECUTIONS_TIME; }
    private float ConsecutiveExecutionsCounter = 0;

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character, WorldState worldState)
    {
        if (ConsecutiveExecutionsCounter > worldState.LastTickTime)
        {
            return new ActionResult(true, "Actions is not active yet from the last execution");
        }
        ConsecutiveExecutionsCounter = worldState.LastTickTime + ConsecutiveExecutionsTime;

        UiElement inventoryPrefab = UiElementsDictionary.GetElement(UiElementsDictionary.PlayerInventory);
        InventoryUi inventoryUi = (InventoryUi)worldState.UiController.InstantiateElement(inventoryPrefab);
        inventoryUi.Initializeinventory((InventoryComponent)character.GetGameComponent(GameComponentDictionary.INVENTORY_COMPONENT_ID));
        worldState.UiController.ShowElement(inventoryUi);
        ActionResult result = new ActionResult(true, "Game has paused succesfully");
        return result;
    }

    public override void UpdateAction()
    {
    }

    protected override void ResolveComponents()
    {
    }

    #endregion
}

public sealed class JumpAction : Action
{
    public override string ActionId { get => ActionsDictionary.JUMP_ACTION_ID; }
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    private StatsComponent m_statsComponent;
    private PhysicsComponent m_physicsComponent;

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character, WorldState worldState)
    {
        float jumpForce = m_statsComponent.GetDynamicStat(StatsNameDictionary.JumpForceStatName).Value;
        Rigidbody rigidbody = m_physicsComponent.Rigidbody;

        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        ActionResult result = new ActionResult(true, "Jumped Succesfully");
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
