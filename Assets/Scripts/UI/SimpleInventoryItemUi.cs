public class SimpleInventoryItemUi : InventoryItemUi
{
    #region InventoryItemUi implementation
    public override void RenderItem()
    {
        m_itemIconImage.sprite = m_itemSprite;
        m_itemQuantityLabel.text = Quantity.ToString();
    }
    #endregion
}
