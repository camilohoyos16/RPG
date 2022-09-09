using System;

[Serializable]
public abstract class InputAction : IAction
{
    private string m_buttonAction;

    public string ActionId { get; set; }

    public InputAction(string input) {
        m_buttonAction = input;
    }

    /// <summary>
    /// Call same <see cref="IAction.ExecuteAction(IControllerCharacter)"/> but putting an input in between 
    /// of the calling of the method and trigger action
    /// </summary>
    /// <param name="character"></param>
    /// <param name="input"></param>
    /// <returns>Whether action was triggered. true: triggered / false: not triggered</returns>
    public bool ExecuteActionWithInput(IControllerCharacter character, string input) {
        if (!CanExecuteAction(input)) {
            return false;
        }

        ExecuteAction(character);
        return true;
    }

    protected bool CanExecuteAction(string input) {
        return InputManager.WasInputUsed(m_buttonAction, input);
    }

    #region IAction Implementation

    public abstract void ExecuteAction(IControllerCharacter character);

    #endregion
}