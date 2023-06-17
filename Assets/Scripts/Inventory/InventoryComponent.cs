using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour, IGameComponent
{
    public string GameComponentId => GameComponentDictionary.INVENTORY_COMPONENT_ID;

    [SerializeField] private List<ItemIdScriptableObject> m_initialItemsId;

    private WieldItemsComponent m_wieldItems;

    public List<InventoryItem> Items { get; } = new List<InventoryItem>();
    private InventoryItem m_currentSelectedItem;

    public InventoryItem GetCurrentSelectedItem() {
        return m_currentSelectedItem;
    }

    public void InitComponent()
    {
        foreach (ItemIdScriptableObject itemId in m_initialItemsId)
        {
            ItemGenericDefinition itemDefinition = ItemDictionary.GetItemDefinitionById(itemId.ItemId);
            AddItem(ItemUtils.CreateNewInventoryItem(itemDefinition));
        }

        m_wieldItems = GetComponent<WieldItemsComponent>();
    }

    public void UpdateComponent(WorldState worldState)
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AttachmentItem item = (AttachmentItem)Items[0];
            m_wieldItems.PrepareItemInQuickAccess(item);
        }
    }

    public void AddItem(WorldItem worldItem) {
        InventoryItem inventoryItem = ItemUtils.TransformWorldItemToInventoryItem(worldItem);
        Items.Add(inventoryItem);
        Debug.Log($"You took {inventoryItem.Name}");
    }

    public void AddItem(InventoryItem inventoryItem) {
        Items.Add(inventoryItem);
    }


    public void RemoveItem(InventoryItem inventoryItem) {

    }

    private void SelectItem(InventoryItem inventoryItem) {
        m_currentSelectedItem = inventoryItem;
    }

    #region Utils

    #endregion
}
