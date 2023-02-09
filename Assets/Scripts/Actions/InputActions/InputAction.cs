using System;

public abstract class InputActionResolver
{
    public abstract void ResolveInputBeforeTriggerAction(IControllerCharacter character, InputContext context, string actionId);
}

public class InputAction
{
    /// TODO: PUT THE ACTION ID HERE TOO AND A PROXY TO THE ACTION VARIABLE

    public Action Action { get; }
    public string ActionId { get; }
    public string Input { get; }

    private InputActionResolver m_inputResolver;

    public InputAction(Action action, string inputId, InputActionResolver inputResolver) {
        Action = action;
        ActionId = action.ActionId;
        Input = inputId;
        m_inputResolver = inputResolver;
    }

    /// <summary>
    /// Call same <see cref="Action.ExecuteAction(IControllerCharacter)"/> but putting an input in between 
    /// of the calling of the method and trigger action
    /// </summary>
    /// <param name="character"></param>
    /// <param name="input"></param>
    /// <returns>Whether action was triggered. true: triggered / false: not triggered</returns>
    public ActionResult ExecuteActionWithInput(IControllerCharacter character, WorldState worldState) {
        InputInfo inputInfo = worldState.CurrentInputContext.GetInfoByActionId(Action.ActionId);

        if (inputInfo.ActionId != Action.ActionId)
        {
            return new ActionResult(false, "Input info passed by Input Controller -> Input Context -> GetInfoByActionId");
        }

        if(inputInfo.Value == 0)
        {
            return new ActionResult(false, "This is temporary while I figure out how to pass the inptut value and continue updateing the action to," +
                "for example stop to walk smoothly");
        }

        m_inputResolver.ResolveInputBeforeTriggerAction(character, worldState.CurrentInputContext, ActionId);

        return Action.ExecuteAction(character, worldState);
    }
}
