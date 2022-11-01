using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentItem : InventoryItem
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region IventoryItem Implementation
    public override void UseItem(ICharacter character) {
        throw new System.NotImplementedException();
    }
    #endregion
}
