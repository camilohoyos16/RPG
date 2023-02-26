using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item_weapon_definition", menuName = "Items/Items Definitions/New Item Weapon", order = 1)]
public class ItemWeaponConfig : ItemGenericConfig
{
    public float Damage;
    public float Weight;
    //public List<Augmenter> Augmenters; WIP ----------------
}
