using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsComponent), typeof(PhysicsComponent))]
public class Player : MonoBehaviour, IControllerCharacter
{
    public PlayerInventory Inventory;
    private List<InputAction> m_actions = new List<InputAction>();
    private StatsComponent m_statsComponent;
    private PhysicsComponent m_physicsComponent;

    public MathUtils.Vector3 EntityPosition { get => transform.position; set => transform.position = value; }

    private void Awake() {
        Inventory = new PlayerInventory();
        m_statsComponent = GetComponent<StatsComponent>();
        m_physicsComponent = GetComponent<PhysicsComponent>();
    }

    private void Start() {
        EventManager.Instance.TriggerGlobal(new OnRegisterEntityEvent(this));    
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
        if(action.ActionId == ActionsDictionary.JUMP_ACTION_ID) {
            action.AddGameComponents(m_statsComponent, m_physicsComponent);
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
    #endregion

    #region IControllerCharacter Implementation 
    
    #endregion
}
