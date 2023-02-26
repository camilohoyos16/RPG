using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item_generic_definition", menuName = "Items/Items Definitions/New Item Generic", order = 1)]
public class ItemClotheConfig : ItemGenericConfig
{
    public float Armour;
    public float Weight;
    public float Appealing;
    public float Scariness;
}

public class ItemClotheDefinition : ItemGenericDefinition
{
    public float Armour;
    public float Weight;
    public float Appealing;
    public float Scariness;

    public ItemClotheDefinition (ItemClotheConfig config) : base(config)
    {
        Armour = config.Armour;
        Weight = config.Weight;
        Appealing = config.Appealing;
        Scariness = config.Scariness;
    }
}
