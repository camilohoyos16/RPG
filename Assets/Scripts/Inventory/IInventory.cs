using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
    public List<IItem> Items { get; set; }

    public void AddItem(IItem item);
    public void RemoveItem(IItem item);
}
