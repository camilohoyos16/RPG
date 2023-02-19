using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsComponent), typeof(PhysicsComponent), typeof(InventoryComponent))]
public class Player : MonoBehaviour, IControllerCharacter
{
    private List<InputAction> m_actions = new List<InputAction>();
    private List<string> m_actionsToRemove = new List<string>();
    private List<Action> m_actionsToAdd = new List<Action>();
    private List<IGameComponent> m_components;

    /// <summary>
    /// TEST !!!!!!!!!!!!!  
    /// </summary>
    public MeleeWeapon Sword;

    public MathUtils.SVector3 EntityPosition { get => transform.position; set => transform.position = value; }
    public float InteractRadius { get => InteractableEntitiesDatabase.CHARACTER_INTERACTABLE_ENTITY_INTERACT_RADIUS; private set { } }

    private void Awake() {
        ResolveComponents();
    }

    private void Start() {
        EventManager.Instance.TriggerGlobal(new OnRegisterEntityEvent(this));    
    }

    private void ResolveComponents() {
        m_components = new();
        m_components.AddRange(GetComponents<IGameComponent>());
    }

    void IEntity.UpdateEntity(WorldState worldState) {
        foreach (InputAction inputAction in m_actions)
        {
            ActionResult actionResult = inputAction.ExecuteActionWithInput(this, worldState);
            //Debug.Log(string.Concat(inputAction.Action.ActionId, ": ", actionResult.WasSuccessful));
        }
        RemoveQueueActions();
        AddQueueActions();
    }


    #region ICharacter implementation
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

    private void AddActionToCharacter(Action action) {
        foreach (string gameComponentId in action.RequiredGameComponentsIds) {
            IGameComponent gameComponent = GetGameComponent(gameComponentId);
            if(gameComponent == default(IGameComponent)) {
                continue;
            }
            /// TEST!!!!!! ----------------------------------------------
            /// This can be set inside interact action when player takes the sword. 
            /// Check if the interacted object is a weapon and assign the weapon there
            if(action is AttackMeleeAction meleeAction) {
                meleeAction.MeleeWeapon = Sword;
            }
            action.AddGameComponents(gameComponent);
        }

        InputAction newInputAction = new InputAction(
            action, 
            InputController.GetActionInputByActionId(action.ActionId),
            InputController.GetInputResolverByActionId(action.ActionId));
        m_actions.Add(newInputAction);
    }

    public Action? GetAction(string actionId) {
        foreach (InputAction inputAction in m_actions) {
            if (inputAction.ActionId.Equals(actionId)) {
                return inputAction.Action;
            }
        }
        return null;
    }

    public bool HasAction(string actionId) {
        foreach (InputAction inputAction in m_actions) {
            if (inputAction.ActionId.Equals(actionId)) {
                return true;
            }
        }
        return false;
    }

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

    private void RemoveAction(string actionId) {
        int actionIndex = -1;
        int actionsCount = m_actions.Count;
        for (int i = 0; i < actionsCount; i++) {
            if (m_actions[i].Action.ActionId.Equals(actionId)) {
                actionIndex = i;
                break;
            }
        }
        if (actionIndex != -1) {
            m_actions.RemoveAt(actionIndex);
        }
    }

    public IGameComponent GetGameComponent(string componentId) {
        return m_components.Find(component => component.GameComponentId.Equals(componentId));
    }

    public void Interact(ICharacter character)
    {
        Debug.Log("Hola señorisimo");
    }
    #endregion

    #region IControllerCharacter Implementation 

    #endregion
}
