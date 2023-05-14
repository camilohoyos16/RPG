using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WieldItem
{
    public AttachmentItem Item;
    public GameObject WorldObject;
    public bool IsBeingUsed;
}

public class WieldItemsComponent : MonoBehaviour
{
    public WieldItem RightHand;
    public WieldItem LeftHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
