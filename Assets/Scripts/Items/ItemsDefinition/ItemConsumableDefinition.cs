using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item_generic_definition", menuName = "Items/Items Definitions/New Item Generic", order = 1)]
public class ItemConsumableDefinition : ItemGenericDefinition
{
    public List<PassiveEffect> PassiveEffects;
    public List<ActiveEffect> ActiveEffects;
}
