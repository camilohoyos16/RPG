using UnityEngine;

public abstract class InventoryItem
{
    private string m_id;
    private string m_name;
    private byte m_maxStack;
    private float m_basePrice;
    private float m_currentPrice;
    private string m_baseDescription;


    #region Properties
    public string Name => m_name;
    public byte MaxStack => m_maxStack;
    public float BasePrice => m_basePrice;
    public float CurrentPrice => m_currentPrice;
    public string BaseDescription => m_baseDescription;
    #endregion

    public InventoryItem()
    {

    }

    public InventoryItem(ItemGenericDefinition itemDefinition)
    {
        m_id = itemDefinition.ItemId.ItemId;
        m_name = itemDefinition.Name;
        m_maxStack = (byte)itemDefinition.MaxStack;
        m_basePrice = itemDefinition.BasePrice;
        m_currentPrice = itemDefinition.BasePrice;
        m_baseDescription = itemDefinition.Description;
    }



    public abstract void UseItem(ICharacter character);
}
