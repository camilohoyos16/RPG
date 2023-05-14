using UnityEngine;

[CreateAssetMenu(fileName = "burn_effect_config", menuName = "Effects/Active/Burn Effect Config", order = 1)]
public class BurnActiveEffectConfig : BasicActiveEffectConfig
{
    public int Ticks;
    public int Cadence;
    public int Damage;
}
