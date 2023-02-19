using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour, IGameComponent
{
    public string GameComponentId => GameComponentDictionary.INVENTORY_COMPONENT_ID;
    public List<InventoryItem> Items { get; } = new List<InventoryItem>();
    private InventoryItem m_currentSelectedItem;

    public InventoryItem GetCurrentSelectedItem() {
        return m_currentSelectedItem;
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
