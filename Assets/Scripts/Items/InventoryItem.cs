using UnityEngine;

public abstract class InventoryItem
{
    private string m_id;
    private string m_name;
    private float m_basePrice;
    private float m_currentPrice;
    private string m_baseDescription;


    #region Properties
    public string Id => m_id;
    public string Name => m_name;
    public float BasePrice => m_basePrice;
    public float CurrentPrice => m_currentPrice;
    public string BaseDescription => m_baseDescription;
    #endregion

    public InventoryItem()
    {

    }

    public InventoryItem(ItemGenericDefinition itemDefinition)
    {
        m_id = itemDefinition.ItemId;
        m_name = itemDefinition.Name;
        m_basePrice = itemDefinition.BasePrice;
        m_currentPrice = itemDefinition.BasePrice;
        m_baseDescription = itemDefinition.Description;
    }



    public abstract void UseItem(ICharacter character);
}

public class SimpleInventoryItem : InventoryItem
{
    public SimpleInventoryItem(ItemGenericDefinition itemGenericDefinition) : base(itemGenericDefinition) { }

    public override void UseItem(ICharacter character)
    {
    }
}
