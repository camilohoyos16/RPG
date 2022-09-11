using UnityEngine;

public class InventoryItem : IItem
{
    /// <summary>
    /// From <see cref="IItem"/>
    /// </summary>
    public ItemData ItemData { get; set; }

    public InventoryItem (IItem item) {
        ItemData = (ItemData)item.ItemData.Clone();
    }

    #region IItem implementation

    public void UseItem() {
        throw new System.NotImplementedException();
    }

    #endregion
}
