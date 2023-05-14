using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected StatsComponent Stats;
    protected StatsComponent OwnerStats;
    protected EffectsContainerComponent EffectsContainer;

    private void Awake() {
        Stats = GetComponent<StatsComponent>();
        EffectsContainer = GetComponent<EffectsContainerComponent>();
    }

    public abstract void Attack(ICharacter owner, WorldState worldState);
}

public abstract class MeleeWeapon : Weapon
{

}
