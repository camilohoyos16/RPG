using UnityEngine;

public class ShopItem : MonoBehaviour, IItem
{
    /// <summary>
    /// From <see cref="IItem"/>
    /// </summary>
    public ItemData ItemData { get; set; }

    public void BuyItem() {
        UseItem();
    }

    #region IItem implementation

    public void UseItem() {
        
    }

    public void UseItem(ICharacter character) {
        throw new System.NotImplementedException();
    }

    #endregion
}
