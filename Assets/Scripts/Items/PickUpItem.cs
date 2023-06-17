public class PickUpItem : WorldItem
{
    public override void InitEntity()
    {
    }

    public override void Interact(ICharacter character)
    {
        if (character is Player player)
        {
            InventoryComponent characterInventory = (InventoryComponent)player.GetGameComponent(GameComponentDictionary.INVENTORY_COMPONENT_ID);
            characterInventory.AddItem(this);
            EventManager.Instance.TriggerGlobal(new OnDestroyEntityEvent(this));
        }
    }

    public override void UpdateEntity(WorldState worldState)
    {
    }
}
