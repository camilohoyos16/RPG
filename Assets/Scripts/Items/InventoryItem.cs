using UnityEngine;

public abstract class InventoryItem
{
    private string m_name;
    private int m_maxStack;
    private float m_basePrice;
    private float m_currentPrice;
    private string m_baseDescription;
    private int m_quantity;

    #region Properties
    public string Name { get => m_name; }
    public int MaxStack { get => m_maxStack; }
    public float BasePrice { get => m_basePrice; }
    public float CurrentPrice { get => m_currentPrice; }
    public string BaseDescription { get => m_baseDescription; }
    //public int Quantity { get => m_quantity; }
    #endregion

    public InventoryItem() {

    }

    public InventoryItem(ItemGenericDefinition itemDefinition) {
        m_name = itemDefinition.Name;
        m_maxStack = itemDefinition.MaxStack;
        m_basePrice = itemDefinition.BasePrice;
        m_currentPrice = itemDefinition.BasePrice;
        m_baseDescription = itemDefinition.Description;
    }

    

    public abstract void UseItem(ICharacter character);
}
