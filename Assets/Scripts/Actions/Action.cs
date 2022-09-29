using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    public virtual string ActionId { get; protected set; }
    public abstract List<string> RequiredGameComponentsIds { get;}
    protected IGameComponent[] m_gameComponents;

    public abstract void ExecuteAction(ICharacter character);

    public void AddGameComponents(params IGameComponent[] gameComponents) {
        m_gameComponents = gameComponents;
        ResolveComponents();
    }

    protected abstract void ResolveComponents();

    public Action(string actionId) {
        ActionId = actionId;
    }
}
