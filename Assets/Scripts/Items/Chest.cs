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
            foreach (InventoryItem item in m_inventory.Items)
            {
                characterInventory.AddItem(item);
            }
        }
    }

    public override void UpdateEntity(WorldState worldState)
    {
    }
}
