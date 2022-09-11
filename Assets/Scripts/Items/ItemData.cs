﻿public class ItemData : IClonable
{
    public bool IsStackable;
    public Stat MaxStack;
    public Stat Quantity;

    public ItemData(ItemConfig itemConfig) {
        IsStackable = itemConfig.IsStackable;
        MaxStack = new Stat(itemConfig.MaxStack);
        Quantity = new Stat(itemConfig.Quantity);
    }

    private ItemData(ItemData itemData) {
        IsStackable = itemData.IsStackable;
        MaxStack = itemData.MaxStack;
        Quantity = itemData.Quantity;
    }

    public ItemData (bool isStackable, Stat maxStack, Stat quantity) {
        IsStackable = isStackable;
        MaxStack = maxStack;
        Quantity = quantity;
    }

    #region IClonable implementation
    public IClonable Clone() {
        return new ItemData(this);
    }
    #endregion
}

