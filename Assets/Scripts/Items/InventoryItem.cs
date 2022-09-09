using UnityEngine;

public class InventoryItem : MonoBehaviour, IItem
{
    /// <summary>
    /// From <see cref="IItem"/>
    /// </summary>
    public ItemData ItemData { get; set; }

    #region IItem implementation

    public void UseItem() {
        throw new System.NotImplementedException();
    }

    #endregion
}
