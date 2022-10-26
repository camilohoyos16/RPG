using UnityEngine;

[RequireComponent (typeof(EffectsApplierController))]
public abstract class ActiveEffectComponent : MonoBehaviour, IEffectComponent
{
    public abstract ActiveEffect GenerateEffect();
}
