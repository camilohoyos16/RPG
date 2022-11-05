using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentItem : InventoryItem
{
    public AttachmentItem(ItemGenericDefinition itemDefinition) : base(itemDefinition) { }

    #region IventoryItem Implementation
    public override void UseItem(ICharacter character) {
        throw new System.NotImplementedException();
    }
    #endregion
}