using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    public virtual string ActionId { get; protected set; }
    public abstract List<string> RequiredGameComponentsIds { get;}
    protected IGameComponent[] m_gameComponents;

    /// <summary>
    /// This is specifically when the an action is trigger or start to use.
    /// </summary>
    /// <param name="character"></param>
    /// <returns></returns>
    public abstract ActionResult ExecuteAction(ICharacter character);

    /// <summary>
    /// This help to make extra behaviors on the action when is laready triggered.
    /// EX: make a lerp between 1 -> 0 when we stop to trigger move input and make 
    /// character stops moving smoothly
    /// </summary>
    public abstract void UpdateAction();

    public void AddGameComponents(params IGameComponent[] gameComponents) {
        m_gameComponents = gameComponents;
        ResolveComponents();
    }

    protected abstract void ResolveComponents();

    public Action()
    {

    }
}
