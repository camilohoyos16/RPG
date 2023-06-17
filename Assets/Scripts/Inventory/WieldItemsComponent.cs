using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WieldItem
{
    public AttachmentItem Item;
    public GameObject WorldObject;
    public bool IsBeingUsed;
}

public class WieldItemsComponent : MonoBehaviour, IGameComponent
{


    public WieldItem Hands;

    public string GameComponentId { get => GameComponentDictionary.WIELD_ITEMS_COMPONENT_ID; }

    public void InitComponent()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateComponent(WorldState worldState)
    {
        throw new System.NotImplementedException();
    }

    public void WeildItem()
    {

    }

}
