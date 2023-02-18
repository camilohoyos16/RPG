using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected StatsComponent Stats;
    protected StatsComponent OwnerStats;
    protected EffectsApplierComponent EffectApplier;

    private void Awake() {
        Stats = GetComponent<StatsComponent>();
        EffectApplier = GetComponent<EffectsApplierComponent>();
    }

    public abstract void Attack(MathUtils.SVector3 position, StatsComponent ownerStats);
}

public abstract class MeleeWeapon : Weapon
{

}
