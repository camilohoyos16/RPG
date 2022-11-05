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
        Items.Add(TransformWorldItemToInventoryItem(worldItem));
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
    private InventoryItem TransformWorldItemToInventoryItem(WorldItem worldItem) {
        switch (worldItem.ItemCategory) {
            case ItemCategory.None:
                break;
            case ItemCategory.Generic:
                break;
            case ItemCategory.Weapon:
                return new WeaponItem(WorldManager.Instance.ItemsDatabase.GetWeaponDefinitionById(worldItem.WorldItemId.ItemId));
            case ItemCategory.Clothe:
                break;
            case ItemCategory.Consumable:
                break;
            case ItemCategory.Collectable:
                break;
            default:
                return null;
        }
        return null;
    }
    #endregion
}
