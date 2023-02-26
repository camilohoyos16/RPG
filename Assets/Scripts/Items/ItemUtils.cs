using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemUtils
{
    public static InventoryItem TransformWorldItemToInventoryItem(WorldItem worldItem)
    {
        switch (worldItem.ItemCategory)
        {
            case ItemCategory.None:
                break;
            case ItemCategory.Generic:
                break;
            case ItemCategory.Weapon:
                return new WeaponItem(ItemDictionary.GetWeaponDefinitionById(worldItem.WorldItemId.ItemId));
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

    public static InventoryItem CreateNewInventoryItem(ItemGenericDefinition itemGenericDefinition)
    {
        switch (itemGenericDefinition)
        {
            case ItemWeaponDefinition weapon:
            {
                return new WeaponItem(weapon);
            }
            default:
                return new SimpleInventoryItem(itemGenericDefinition);
        }
    }
}
