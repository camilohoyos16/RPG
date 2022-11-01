using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour, IGameComponent
{
    public string GameComponentId => GameComponentDictionary.INVENTORY_COMPONENT_ID;
    public List<InventoryItem> Items { get; }
    private InventoryItem m_currentSelectedItem;

    public InventoryItem GetCurrentSelectedItem() {
        return m_currentSelectedItem;
    }

    public void AddItem(WorldItem item) {

    }

    public void AddItem(InventoryItem item) {

    }


    public void RemoveItem(InventoryItem item) {

    }

    private void SelectItem(InventoryItem item) {
        m_currentSelectedItem = item;
    }
}
