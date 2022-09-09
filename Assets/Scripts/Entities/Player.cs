using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IControllerCharacter
{
    private List<InputAction> m_actions = new List<InputAction>();
    public Rigidbody Rigidbody; //Need to check this and actions definitions

    public MathUtils.Vector3 EntityPosition { get => transform.position; set => transform.position = value; }

    private void Start() {
        EventManager.Instance.TriggerGlobal(new OnRegisterEntityEvent(this));    
    }


    void IEntity.UpdateEntity() {
        foreach (InputAction action in m_actions) {
            bool foundAction = action.ExecuteActionWithInput(this, Input.inputString.ToLower());
            if (foundAction) {
                break;
            }
        }
    }

    #region IControllerCharacter Implementation 
    /// <summary>
    /// This could be anojther calss to implement just the definitions of the actions. In that way I can give to player a chicken jump
    /// </summary>
    public void Attack() {
        throw new System.NotImplementedException();
    }

    public void Jump() {
        Rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    public void Move() {
        throw new System.NotImplementedException();
    }

    public void AddActionToCharacter(InputAction action) {
        m_actions.Add(action);
    }

    public bool HasAction(string actionId) {
        foreach (InputAction action in m_actions) {
            if (action.ActionId.Equals(actionId)) {
                return true;
            }
        }
        return false;
    }

    public void RemoveAction(string actionId) {
        int actionIndex = -1;
        int actionsCount = m_actions.Count;
        for (int i = 0; i < actionsCount; i++) {
            if (m_actions[i].ActionId.Equals(actionId)) {
                actionIndex = i;
                break;
            }
        }
        if(actionIndex != -1) {
            m_actions.RemoveAt(actionIndex);
        }
    }

    #endregion
}
