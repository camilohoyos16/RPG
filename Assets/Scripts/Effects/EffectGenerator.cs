using System.Collections;
using UnityEngine;

public static class EffectGenerator
{
    public static BasicActiveEffect GenerateActiveEffect(
        ICharacter attacker,
        ICharacter target,
        BasicActiveEffectConfig config)
    {
        switch (config)
        {
            case WeaponDamageEffectConfig:
                return new GenericWeaponDamageEffect(attacker, target, config);
            case TickActiveEffectConfig tickActiveEffectConfig:
                return new TickActiveEffect(
                    attacker,
                    target,
                    config,
                    tickActiveEffectConfig.Ticks,
                    tickActiveEffectConfig.Cadence);
            default:
                return new BasicActiveEffect(attacker, target, config);
        }
    }

    public static BasicPassiveEffect GeneratePassiveEffect(
        ICharacter attacker,
        ICharacter target,
        PassiveEffectConfig config)
    {
        switch (config)
        {
            default:
                return new BasicPassiveEffect(attacker, target, config);
        }
    }
}
