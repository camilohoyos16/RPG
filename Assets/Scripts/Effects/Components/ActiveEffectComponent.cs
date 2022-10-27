using UnityEngine;

[RequireComponent (typeof(EffectsApplierComponent))]
public abstract class ActiveEffectComponent : MonoBehaviour, IEffectComponent
{
    public EffectConfig EffectConfig;
    public abstract ActiveEffect GenerateEffect(StatsComponent ownerStats);
}
