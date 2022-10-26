
public class GenericDamageEffectComponent : ActiveEffectComponent
{
    public GenericDamageEffectConfig GenericDamageEffectConfig;

    public override ActiveEffect GenerateEffect() {
        return new GenericDamageEffect(GenericDamageEffectConfig.Value);
    }
}
