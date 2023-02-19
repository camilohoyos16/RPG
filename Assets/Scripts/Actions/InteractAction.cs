using System.Collections.Generic;

public sealed class InteractAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }
    public override string ActionId { get => ActionsDictionary.INTERACT_ACTION_ID; }
    public override float ConsecutiveExecutionsTime { get => ActionsDictionary.INTERACT_ACTION_CONSECUTIVE_EXECUTIONS_TIME; }
    private float ConsecutiveExecutionsCounter;

    private List<IInteractable> m_interactObjects;

    public List<IInteractable> GetInteracObjects() {
        return m_interactObjects;
    }

    public InteractAction()
    {
        m_interactObjects = new();
        ConsecutiveExecutionsCounter = 0;
    }

    public void AddObjectToInteractWith(IInteractable interactObject)
    {
        if (!m_interactObjects.Contains(interactObject))
        {
            m_interactObjects.Add(interactObject);
        }
    }

    public bool HasObject(IInteractable interactable)
    {
        return m_interactObjects.Contains(interactable);
    }

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character, WorldState worldState) {

        if(ConsecutiveExecutionsCounter > worldState.LastTickTime)
        {
            return new ActionResult(true, "Actions is not active yet from the last execution");
        }

        IInteractable interactableObject = GetBestObjectToInteractWith();
        interactableObject.Interact(character);
        EventManager.Instance.TriggerGlobal(new OnDestroyEntityEvent(interactableObject));

        if(m_interactObjects.Count == 0)
        {
            character.QueueActionToRemove(ActionId);
        }

        ActionResult result = new ActionResult(true, "Interacted with object");
        return result;

        ConsecutiveExecutionsCounter = worldState.LastTickTime + ConsecutiveExecutionsTime;
    }

    private IInteractable GetBestObjectToInteractWith()
    {
        IInteractable bestOption = m_interactObjects[0];
        m_interactObjects.Remove(bestOption);
        return bestOption;
    }

    public override void UpdateAction()
    {
    }

    protected override void ResolveComponents() {
    }
    #endregion
}
