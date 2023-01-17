using System;
public class InputAction
{
    public Action Action;
    public string InputId { get; }

    public InputAction(Action action, string inputId) {
        Action = action;
        InputId = inputId;
    }

    /// <summary>
    /// Call same <see cref="Action.ExecuteAction(IControllerCharacter)"/> but putting an input in between 
    /// of the calling of the method and trigger action
    /// </summary>
    /// <param name="character"></param>
    /// <param name="input"></param>
    /// <returns>Whether action was triggered. true: triggered / false: not triggered</returns>
    public bool ExecuteActionWithInput(IControllerCharacter character, string input) {
        if (!CanExecuteAction(input)) {
            return false;
        }

        Action.ExecuteAction(character);
        return true;
    }

    protected bool CanExecuteAction(string input) {
        return InputUtilities.WasActionInputTriggered(InputId, input);
    }
}
