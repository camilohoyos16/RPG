using System;
public class InputAction
{
    /// TODO: PUT THE ACTION ID HERE TOO AND A PROXY TO THE ACTION VARIABLE

    public Action Action;
    public string Input { get; }

    public InputAction(Action action, string inputId) {
        Action = action;
        Input = inputId;
    }

    /// <summary>
    /// Call same <see cref="Action.ExecuteAction(IControllerCharacter)"/> but putting an input in between 
    /// of the calling of the method and trigger action
    /// </summary>
    /// <param name="character"></param>
    /// <param name="input"></param>
    /// <returns>Whether action was triggered. true: triggered / false: not triggered</returns>
    public ActionResult ExecuteActionWithInput(IControllerCharacter character) {
        InputInfo inputInfo = InputController.currentInputContext.GetInfoByActionId(Action.ActionId);

        if (inputInfo.ActionId != Action.ActionId)
        {
            return new ActionResult(false, "Input info passed by Input Controller -> Input Context -> GetInfoByActionId");
        }

        if(inputInfo.Value == 0)
        {
            return new ActionResult(false, "This is temporary while I figure out how to pass the inptut value and continue updateing the action to," +
                "for example stop to walk smoothly");
        }

        return Action.ExecuteAction(character);
    }
}
