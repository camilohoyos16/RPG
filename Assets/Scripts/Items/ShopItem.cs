using UnityEngine;

public class ShopItem : MonoBehaviour, IItem
{
    /// <summary>
    /// From <see cref="IItem"/>
    /// </summary>
    public ItemData ItemData { get; set; }

    #region IItem implementation

    public void UseItem() {
        
    }

    public void BuyItem() {
        UseItem();
    }

    #endregion
}
