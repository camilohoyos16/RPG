using UnityEngine;

[RequireComponent (typeof(EffectsApplierController))]
public abstract class PassiveEffectComponent : MonoBehaviour, IEffectComponent
{
    public abstract PassiveEffect GenerateEffect();
}
