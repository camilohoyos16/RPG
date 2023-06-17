using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCharacter : MonoBehaviour, ICharacter
{
    private List<InputAction> m_actions = new List<InputAction>();
    private List<IGameComponent> m_components;
    private List<string> m_actionsToRemove = new List<string>();
    private List<Action> m_actionsToAdd = new List<Action>();

    public float InteractRadius { get => InteractableEntitiesDatabase.CHARACTER_INTERACTABLE_ENTITY_INTERACT_RADIUS; }

    public MathUtils.SVector3 EntityPosition { get => transform.position; set => transform.position = value; }

    public Action? GetAction(string actionId)
    {
        foreach (InputAction inputAction in m_actions)
        {
            if (inputAction.ActionId.Equals(actionId))
            {
                return inputAction.Action;
            }
        }
        return null;
    }

    public IGameComponent GetGameComponent(string componentId)
    {
        return m_components.Find(component => component.GameComponentId.Equals(componentId));
    }

    public bool HasAction(string actionId)
    {
        foreach (InputAction inputAction in m_actions)
        {
            if (inputAction.ActionId.Equals(actionId))
            {
                return true;
            }
        }
        return false;
    }

    public void Interact(ICharacter character)
    {
        Debug.Log("Hola señorisimo");
    }

    #region Add actions
    public void QueueActionToAdd(Action action)
    {
        m_actionsToAdd.Add(action);
    }
    private void AddQueueActions()
    {
        foreach (Action action in m_actionsToAdd)
        {
            AddActionToCharacter(action);
        }

        m_actionsToAdd.Clear();
    }

    private void AddActionToCharacter(Action action)
    {
        foreach (string gameComponentId in action.RequiredGameComponentsIds)
        {
            IGameComponent gameComponent = GetGameComponent(gameComponentId);
            if (gameComponent == default(IGameComponent))
            {
                continue;
            }
            action.AddGameComponents(gameComponent);
        }

        InputAction newInputAction = new InputAction(
            action,
            InputController.GetActionInputByActionId(action.ActionId),
            InputController.GetInputResolverByActionId(action.ActionId));
        m_actions.Add(newInputAction);
    }
    #endregion

    #region Remove actions
    public void QueueActionToRemove(string actionId)
    {
        m_actionsToRemove.Add(actionId);
    }

    private void RemoveQueueActions()
    {
        foreach (string actionId in m_actionsToRemove)
        {
            RemoveAction(actionId);
        }
        m_actionsToRemove.Clear();
    }

    private void RemoveAction(string actionId)
    {
        int actionIndex = -1;
        int actionsCount = m_actions.Count;
        for (int i = 0; i < actionsCount; i++)
        {
            if (m_actions[i].Action.ActionId.Equals(actionId))
            {
                actionIndex = i;
                break;
            }
        }
        if (actionIndex != -1)
        {
            m_actions.RemoveAt(actionIndex);
        }
    }
    #endregion

    public void UpdateEntity(WorldState worldState)
    {
        foreach (IGameComponent component in m_components)
        {
            component.UpdateComponent(worldState);
        }

        foreach (InputAction inputAction in m_actions)
        {
            ActionResult actionResult = inputAction.ExecuteActionWithInput(this, worldState);
            //Debug.Log(string.Concat(inputAction.Action.ActionId, ": ", actionResult.WasSuccessful));
        }
        RemoveQueueActions();
        AddQueueActions();
    }

    public void InitEntity()
    {
        ResolveComponents();
        EventManager.Instance.TriggerGlobal(new OnRegisterEntityEvent(this));
    }

    private void ResolveComponents()
    {
        m_components = new();
        m_components.AddRange(GetComponents<IGameComponent>());

        foreach (IGameComponent component in m_components)
        {
            component.InitComponent();
        }
    }
}
