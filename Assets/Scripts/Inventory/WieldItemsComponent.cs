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
    public GameObject HandObject;

    public WieldItem Hands;

    private AttachmentItem m_handsQuickAccess;
    /// private AttachmentItem m_handsQuickAccess;
    /// private AttachmentItem m_handsQuickAccess; <= CLOTHES
    /// private AttachmentItem m_handsQuickAccess;


    public string GameComponentId { get => GameComponentDictionary.WIELD_ITEMS_COMPONENT_ID; }

    public void InitComponent()
    {
    }

    public void UpdateComponent(WorldState worldState)
    {
    }

    public void WeildItem()
    {
        Hands = new WieldItem();
        Hands.Item = m_handsQuickAccess;
        GameObject prefab = ItemDictionary.GetWeaponDefinitionById(m_handsQuickAccess.Id).ItemPrefab;
        GameObject newWorlItem = Instantiate(prefab, HandObject.transform, true);
        //newWorlItem.transform.SetParent(,);
        newWorlItem.transform.localPosition = Vector3.zero;
        newWorlItem.transform.rotation = HandObject.transform.rotation;
        Hands.WorldObject = newWorlItem;
    }

    public void PrepareItemInQuickAccess(AttachmentItem item)
    {
        m_handsQuickAccess = item;
    }

}
