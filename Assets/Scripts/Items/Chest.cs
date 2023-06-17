using System.Collections.Generic;

public class Chest : WorldItem
{
    private InventoryComponent m_inventory;

    public override void InitEntity()
    {
        m_inventory = GetComponent<InventoryComponent>();
        m_inventory.InitComponent();
    }

    public override void Interact(ICharacter character)
    {
        if (character is Player player)
        {
            InventoryComponent characterInventory = (InventoryComponent)player.GetGameComponent(GameComponentDictionary.INVENTORY_COMPONENT_ID);
            List<int> indexesToRemove = new List<int>();

            for (int i = 0; i < m_inventory.Items.Count; i++)
            {
                InventoryItem item = m_inventory.Items[i];
                characterInventory.AddItem(item);
            }

            m_inventory.Items.Clear();
        }
    }

    public override void UpdateEntity(WorldState worldState)
    {
    }
}
