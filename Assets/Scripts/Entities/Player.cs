using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsComponent), typeof(PhysicsComponent), typeof(InventoryComponent))]
public class Player : MonoBehaviour, IControllerCharacter
{
    private List<InputAction> m_actions = new List<InputAction>();
    private List<IGameComponent> m_components;

    /// <summary>
    /// TEST !!!!!!!!!!!!!  
    /// </summary>
    public MeleeWeapon Sword;

    public MathUtils.Vector3 EntityPosition { get => transform.position; set => transform.position = value; }

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

    void IEntity.UpdateEntity() {
        foreach (InputAction inputAction in m_actions) {
            bool foundAction = inputAction.ExecuteActionWithInput(this, Input.inputString.ToLower());
            if (foundAction) {
                break;
            }
        }
    }

    #region ICharacter implementation

    public void AddActionToCharacter(Action action) {
        foreach (string gameComponentId in action.RequiredGameComponentsIds) {
            IGameComponent gameComponent = GetGameComponent(gameComponentId);
            if(gameComponent == default(IGameComponent)) {
                continue;
            }
            /// TEST!!!!!! ----------------------------------------------
            if(action is AttackMeleeAction meleeAction) {
                meleeAction.MeleeWeapon = Sword;
            }
            action.AddGameComponents(gameComponent);
        }

        InputAction newInputAction = new InputAction(action, InputManager.GetInputByAction(action.ActionId));
        m_actions.Add(newInputAction);
    }

    public Action GetAction(string actionId) {
        foreach (InputAction inputAction in m_actions) {
            if (inputAction.Action.ActionId.Equals(actionId)) {
                return inputAction.Action;
            }
        }
        return null;
    }

    public bool HasAction(string actionId) {
        foreach (InputAction inputAction in m_actions) {
            if (inputAction.Action.ActionId.Equals(actionId)) {
                return true;
            }
        }
        return false;
    }

    public void RemoveAction(string actionId) {
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
    #endregion

    #region IControllerCharacter Implementation 

    #endregion
}
