
public class GenericDamageEffectComponent : ActiveEffectComponent
{
    public override ActiveEffect GenerateEffect(StatsComponent ownerStats) {

        return new GenericDamageEffect();
    }
}
