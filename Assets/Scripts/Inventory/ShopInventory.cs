﻿using System.Collections.Generic;

public class ShopInventory : IInventory
{
    /// <summary>
    /// From <see cref="IInventory"/>
    /// </summary>
    public List<IItem> Items { get; private set; }

    public void SellItem(ShopItem item) {

    }

    #region IInventory implementation
    public void AddItem(IItem item) {
        throw new System.NotImplementedException();
    }

    public void RemoveItem(IItem item) {
        throw new System.NotImplementedException();
    }
    #endregion
}