using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
    public string ActionId {
        get; set;
    }

    public abstract void ExecuteAction(IControllerCharacter character);
}
