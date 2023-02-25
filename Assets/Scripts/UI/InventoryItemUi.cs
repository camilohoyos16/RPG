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
    private byte m_quantity;

    public byte Quantity => m_quantity;
    public byte MaxStack => m_itemData.MaxStack;

    public virtual void InitializeItem(InventoryItem itemData, Sprite itemSprite, byte initialQuantity = 1)
    {
        m_itemData = itemData;
        m_quantity = initialQuantity;
        m_itemSprite = itemSprite;
    }

    public void AddItems(byte quantityToAdd)
    {
        m_quantity += quantityToAdd;
    }

    public void RemoveItems(byte quanityToRemove)
    {
        m_quantity -= quanityToRemove;
    }

    public abstract void RenderItem();
}
