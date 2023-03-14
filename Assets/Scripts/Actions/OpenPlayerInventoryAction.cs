using System.Collections.Generic;

public sealed class OpenPlayerInventoryAction : Action
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

        character.QueueActionToRemove(ActionId);

        CloseUiElementAction action;
        if (character.HasAction(ActionsDictionary.HIDE_UI_ELEMENT_ACTION_ID))
        {
            action = (CloseUiElementAction)character.GetAction(ActionsDictionary.HIDE_UI_ELEMENT_ACTION_ID);
        }
        else
        {
            action = new CloseUiElementAction();
            character.QueueActionToAdd(action);
        }

        action.AddAnotherUiElementToHide(inventoryUi);


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

public sealed class CloseUiElementAction : Action
{
    public override string ActionId { get => ActionsDictionary.HIDE_UI_ELEMENT_ACTION_ID; }
    public override List<string> RequiredGameComponentsIds { get => new(); }
    public override float ConsecutiveExecutionsTime { get => ActionsDictionary.INTERACT_ACTION_CONSECUTIVE_EXECUTIONS_TIME; }
    private float ConsecutiveExecutionsCounter = 0;

    private Stack<UiElement> m_uiElements;


    public CloseUiElementAction()
    {
        m_uiElements = new Stack<UiElement>();
    }

    public void AddAnotherUiElementToHide(UiElement element)
    {
        m_uiElements.Push(element);
    }

    private UiElement GetNextElementToHide()
    {
        return m_uiElements.Pop();
    }

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character, WorldState worldState)
    {
        if (ConsecutiveExecutionsCounter > worldState.LastTickTime)
        {
            return new ActionResult(true, "Actions is not active yet from the last execution");
        }
        ConsecutiveExecutionsCounter = worldState.LastTickTime + ConsecutiveExecutionsTime;

        worldState.UiController.HideElement(GetNextElementToHide());

        if (m_uiElements.Count == 0)
        {
            character.QueueActionToRemove(ActionId);
            character.QueueActionToAdd(new OpenPlayerInventoryAction());
        }

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
