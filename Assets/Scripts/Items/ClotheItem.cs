using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClotheItem : AttachmentItem
{
    private float m_armour;
    private float m_weight;
    private float m_appealing;
    private float m_scariness;

    #region Properties
    public float Armour { get => m_armour; }
    public float Weight { get => m_weight; }
    public float Appealing { get => m_appealing; }
    public float Scariness { get => m_scariness; }
    #endregion

    public ClotheItem(ItemClotheDefinition itemDefinition)
       : base(itemDefinition) {
        m_armour = itemDefinition.Armour;
        m_weight = itemDefinition.Weight;
        m_appealing = itemDefinition.Appealing;
        m_scariness = itemDefinition.Scariness;
    }
}
