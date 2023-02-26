using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    [SerializeField] private RectTransform m_parent;
    [SerializeField] private RectTransform m_content;

    [SerializeField] private InventoryItemUi m_inventoryItemUiPrefab;
    private List<InventoryItem> m_inventoryItems;
    private List<InventoryItemUi> m_inventoryItemsUi;

    public void Initializeinventory(InventoryComponent inventoryComponent)
    {
        m_inventoryItems = new List<InventoryItem>();
        m_inventoryItems = inventoryComponent.Items;

        foreach (InventoryItem item in m_inventoryItems)
        {
            List<InventoryItemUi> itemWithSameId = GetAllItemsById(item.Id);

            foreach (InventoryItemUi itemUi in itemWithSameId)
            {
                if(itemUi.Quantity < itemUi.MaxStack)
                {
                    itemUi.AddItems(1);
                    continue;
                }
            }

            InventoryItemUi newItemUi = Instantiate(m_inventoryItemUiPrefab, m_content);
            ItemGenericDefinition definition = ItemDictionary.GetItemDefinitionById(item.Id);
            newItemUi.InitializeItem(item, definition.ItemSprite);
            m_inventoryItemsUi.Add(newItemUi);
        }

        RenderInventory();
    }

    private void RenderInventory()
    {
        foreach (InventoryItemUi itemUi in m_inventoryItemsUi)
        {
            itemUi.RenderItem();
        }
    }

    private List<InventoryItemUi> GetAllItemsById(string idToSearch)
    {
        List<InventoryItemUi> items = new List<InventoryItemUi>();
        foreach (InventoryItemUi itemUi in m_inventoryItemsUi)
        {
            if (itemUi.ItemDefinitionId.Equals(idToSearch))
            {
                items.Add(itemUi);
            }
        }

        return items;
    }
}
