using System.Collections.Generic;

public sealed class WieldMeeleWeaponAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => 
            new() { 
                GameComponentDictionary.WIELD_ITEMS_COMPONENT_ID,
                GameComponentDictionary.INVENTORY_COMPONENT_ID
            }; }

    public override string ActionId { get => ActionsDictionary.WIELD_MEELE_WEAPON_ACTION_ID; }

    private WieldItemsComponent m_wieldItems;
    private InventoryComponent m_inventory;

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character, WorldState worldState) {
        character.QueueActionToAdd(new AttackMeleeAction());
        character.QueueActionToAdd(new WieldDistanceWeaponAction());
        character.QueueActionToRemove(ActionId);
        m_wieldItems.WeildItem();
        ActionResult result = new ActionResult(true, "Wielded Melee Weapon");
        return result;
    }

    public override void UpdateAction()
    {
    }

    protected override void ResolveComponents() {
        foreach (IGameComponent gameComponent in m_gameComponents)
        {
            switch (gameComponent.GameComponentId)
            {
                case GameComponentDictionary.WIELD_ITEMS_COMPONENT_ID:
                    m_wieldItems = (WieldItemsComponent)gameComponent;
                    break;
                case GameComponentDictionary.INVENTORY_COMPONENT_ID:
                    m_inventory = (InventoryComponent)gameComponent;
                    break;
                default:
                    break;
            }
        }
    }
    #endregion
}