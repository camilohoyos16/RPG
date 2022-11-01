using UnityEngine;

public abstract class InventoryItem
{
    /// <summary>
    /// From <see cref="IItem"/>
    /// </summary>
    public ItemData ItemData { get; set; }

    private int m_maxStack;
    private int m_quantity;
    private string m_description;

    public abstract void UseItem(ICharacter character);
}
