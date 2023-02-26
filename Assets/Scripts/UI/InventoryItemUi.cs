using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class InventoryItemUi : MonoBehaviour
{
    [SerializeField] private RectTransform m_parent;
    [SerializeField] protected Image m_itemIconImage;
    [SerializeField] protected TextMeshProUGUI m_itemQuantityLabel;
    protected Sprite m_itemSprite;

    private InventoryItem m_itemData;

    public int Quantity { get; private set; }
    public int MaxStack { get; private set; }
    public string ItemDefinitionId => m_itemData.Id;

    public virtual void InitializeItem(InventoryItem itemData, Sprite itemSprite, int initialQuantity = 1)
    {
        m_itemData = itemData;
        Quantity = initialQuantity;
        m_itemSprite = itemSprite;

        ItemGenericDefinition definition = ItemDictionary.GetItemDefinitionById(itemData.Id);
        MaxStack = definition.UiMaxStack;
    }

    public void AddItems(int quantityToAdd)
    {
        Quantity += quantityToAdd;
    }

    public void RemoveItems(int quanityToRemove)
    {
        Quantity -= quanityToRemove;
    }

    public abstract void RenderItem();
}
