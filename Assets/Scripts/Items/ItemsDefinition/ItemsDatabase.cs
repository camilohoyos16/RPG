using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DatabaseDictionary
{
    public const string ITEM_DATABASE_ID = "item_database";
    public const string ITEM_VISUALS_DATABASE_ID = "item_visual_database";
    public const string DYNAMIC_STATS_DATABASE_ID = "dynamic_stats_database";
    public const string TAGS_DATABASE_ID = "tags_database";
}

public enum ItemCategory
{
    None,
    Generic,
    Weapon,
    Clothe,
    Consumable,
    Collectable,
}

public interface IDatabase
{
    public string DatabaseId { get; }

    public void Initialize();
}

[CreateAssetMenu(fileName = "ItemsDatabase", menuName = "Items/New ItemsDatabase", order = 1)]
public class ItemsDatabase : ScriptableObject, IDatabase
{
    public string DatabaseId => DatabaseDictionary.ITEM_DATABASE_ID;

    #region ItemsId
    public ItemIdScriptableObject world_item_sword_id;
    #endregion

    public ItemWeaponConfig DefaultItemWeaponDefinition;
    #region ItemsDefinition

    [SerializeField] private List<ItemGenericConfig> ItemsConfig;

    public void Initialize()
    {
        ItemDictionary.ItemSwordDefinition = new ItemWeaponDefinition(DefaultItemWeaponDefinition);
        ItemDictionary.Initialize(ItemsConfig);
    }
    #endregion
}

public class ItemGenericDefinition
{
    public string ItemId;
    public string Name;
    public string Description;
    public float BasePrice;
    public int UiMaxStack;
    public Sprite ItemSprite;
    public GameObject ItemPrefab;

    public ItemGenericDefinition(ItemGenericConfig config)
    {
        ItemId = config.ItemId.ItemId;
        Name = config.Name;
        Description = config.Description;
        BasePrice = config.BasePrice;
        UiMaxStack = config.UiMaxStack;
        ItemSprite = config.ItemSprite;
        ItemPrefab = config.ItemPrefab;
    }
}

public class ItemWeaponDefinition : ItemGenericDefinition
{
    public float Damage;
    public float Weight;
    //public List<Augmenter> Augmenters; WIP ----------------

    public ItemWeaponDefinition(ItemWeaponConfig config) : base(config)
    {
        Damage = config.Damage;
        Weight = config.Weight;
    }
}


public static class ItemDictionary
{
    public static ItemWeaponDefinition ItemSwordDefinition;
    public static Dictionary<string, ItemGenericDefinition> AllItems;
    public static Dictionary<string, ItemWeaponDefinition> ItemsWeapon;

    public static void Initialize(List<ItemGenericConfig> ItemsGenericDefinitions)
    {
        ItemsWeapon = new();
        AllItems = new();
        foreach (ItemGenericConfig itemGeneric in ItemsGenericDefinitions)
        {
            AllItems.Add(itemGeneric.ItemId.ItemId, new (itemGeneric));
            switch (itemGeneric)
            {
                case ItemWeaponConfig weaponConfig:
                {
                    ItemWeaponDefinition weaponDefinition = new(weaponConfig);
                    ItemsWeapon.Add(weaponDefinition.ItemId, weaponDefinition);
                    break; 
                }
                default:
                    break;
            }
        }
    }

    public static ItemGenericDefinition GetItemDefinitionById(string id)
    {
        if (AllItems.ContainsKey(id))
        {
            return AllItems[id];
        }

        return ItemSwordDefinition;
    }

    public static ItemWeaponDefinition GetWeaponDefinitionById(string id)
    {
        if (ItemsWeapon.ContainsKey(id))
        {
            return ItemsWeapon[id];
        }

        return ItemSwordDefinition;
    }

}