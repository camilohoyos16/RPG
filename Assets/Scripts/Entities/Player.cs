using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IControllerCharacter
{
    private List<InputAction> m_actions = new List<InputAction>();
    public Rigidbody Rigidbody; //Need to check this and actions definitions

    private void Start() {
        
    }

    public void AddActionToPlayer(InputAction action){
        m_actions.Add(action);
    }

    private void Update() {
        foreach (InputAction action in m_actions) {
            bool foundAction = action.ExecuteActionWithInput(this, Input.inputString.ToLower());
            if (foundAction) {
                break;
            }
        }
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
    #endregion
}
