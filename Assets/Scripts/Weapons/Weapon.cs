using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public StatsComponent Stats;

    public abstract void Attack();
}

public class Sword : Weapon
{
    public override void Attack() {
        
    }
}
