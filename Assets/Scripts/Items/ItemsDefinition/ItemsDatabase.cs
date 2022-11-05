using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCategory
{
    None,
    Generic,
    Weapon,
    Clothe,
    Consumable,
    Collectable,
}

[CreateAssetMenu(fileName = "ItemsDatabase", menuName = "Items/New ItemsDatabase", order = 1)]
public class ItemsDatabase : ScriptableObject
{
    #region ItemsId
    public ItemIdScriptableObject world_item_sword_id;
    #endregion

    public ItemWeaponDefinition DefaultItemWeaponDefinition;
    #region ItemsDefinition

    public List<ItemWeaponDefinition> ItemWeaponDefinitions;
    public Dictionary<string, ItemWeaponDefinition> ItemWeaponDefinitionsDictionary;

    public void Initialize() {
        ItemWeaponDefinitionsDictionary = new Dictionary<string, ItemWeaponDefinition>();
        foreach (ItemWeaponDefinition itemDefinition in ItemWeaponDefinitions) {
            ItemWeaponDefinitionsDictionary.Add(itemDefinition.ItemId.ItemId, itemDefinition);
        }
    }

    public ItemWeaponDefinition GetWeaponDefinitionById(string id) {
        if (ItemWeaponDefinitionsDictionary.ContainsKey(id)) {
            return ItemWeaponDefinitionsDictionary[id];
        }

        return DefaultItemWeaponDefinition;
    }
    #endregion

}
