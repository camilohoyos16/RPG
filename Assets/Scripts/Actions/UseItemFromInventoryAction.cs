using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// NOTE: Se necesita crear otro action para la interaccion de los item desde el menu rapido
/// </summary>
public class UseItemFromInventoryAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.INVENTORY_COMPONENT_ID}; }

    public UseItemFromInventoryAction() : base(ActionsDictionary.USE_ITEM_FROM_INVENTORY_ACTION_ID) { }


    private InventoryComponent m_inventoryComponent;

    public override ActionResult ExecuteAction(ICharacter character) {
        InventoryItem currentitem = m_inventoryComponent.GetCurrentSelectedItem();
        switch (currentitem) {
            case AttachmentItem:
                UseAttachmentItem((AttachmentItem)currentitem);
                break;
            case ConsumableItem:
                UseConsumableItem((ConsumableItem)currentitem, character);
                break;
            default:
                break;
        }

        return new ActionResult(true, "");
    }

    private void UseAttachmentItem(AttachmentItem item) {
        /// TODO.
    }

    private void UseConsumableItem(ConsumableItem item, ICharacter character) {
        item.UseItem(character);
    }

    protected override void ResolveComponents() {
        foreach (IGameComponent gameComponent in m_gameComponents) {
            switch (gameComponent.GameComponentId) {
                case GameComponentDictionary.STATS_COMPONENT_ID:
                    m_inventoryComponent = (InventoryComponent)gameComponent;
                    break;
                default:
                    break;
            }
        }
    }

}
