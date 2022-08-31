using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
    public abstract void ExecuteAction(IControllerCharacter character);
}
