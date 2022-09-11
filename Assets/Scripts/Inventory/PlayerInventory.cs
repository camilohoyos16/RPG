using System.Collections.Generic;

public class PlayerInventory : IInventory
{
    /// <summary>
    /// From <see cref="IInventory"/>
    /// </summary>
    public List<IItem> Items { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public PlayerInventory() {
        Items = new List<IItem>();
    }

    public void InspectItem(InventoryItem item) {

    }

    #region IInventory implementation
    public void AddItem(IItem item) {
        InventoryItem newItem = new InventoryItem(item);
        Items.Add(newItem);
    }

    public void RemoveItem(IItem item) {
        throw new System.NotImplementedException();
    }
    #endregion
}
