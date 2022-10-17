public abstract class Effect
{
    public string StatToAffect;

    protected StatsComponent AttackerStats;
    protected StatsComponent TargetStats;

    /// <summary>
    /// Modified stat's value whether is needed
    /// </summary>
    /// <param name="valueToResolve"></param>
    /// <returns>Final value after was being modified by effect</returns>
    public abstract float ActivateEffect(float valueToResolve);
}
