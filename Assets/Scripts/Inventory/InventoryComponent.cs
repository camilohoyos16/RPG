using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour, IGameComponent
{
    public string GameComponentId => GameComponentDictionary.INVENTORY_COMPONENT_ID;
    public List<IItem> Items { get; }


    public void AddItem(IItem item) {

    }

    public void RemoveItem(IItem item) {

    }
}
