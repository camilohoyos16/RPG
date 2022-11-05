using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : AttachmentItem
{
    private float m_damage;
    private float m_weight;
    //private List<augmenter> Augmenters; WIP

    public WeaponItem(ItemWeaponDefinition itemDefinition) 
        : base(itemDefinition) {
        m_damage = itemDefinition.Damage;
        m_weight = itemDefinition.Weight;
    }
                      
    #region Properties
    public float Damage { get => m_damage; }
    public float Weight { get => m_weight; }
    #endregion
}
