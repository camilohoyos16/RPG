using UnityEngine;

[RequireComponent (typeof(EffectsApplierComponent))]
public abstract class PassiveEffectComponent : MonoBehaviour, IEffectComponent
{
    public abstract PassiveEffect GenerateEffect(StatsComponent ownerStats);
}
