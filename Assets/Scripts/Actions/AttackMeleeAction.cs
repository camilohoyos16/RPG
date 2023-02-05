using System.Collections.Generic;

public sealed class AttackMeleeAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => new() { GameComponentDictionary.STATS_COMPONENT_ID, GameComponentDictionary.PHYSICS_COMPONENT_ID }; }

    public override string ActionId { get => ActionsDictionary.ATTACK_MELEE_ACTION_ID; }

    public MeleeWeapon MeleeWeapon;

    private StatsComponent m_ownerStatsComponent;

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character) {
        //charcter.Attack()
        MeleeWeapon.Attack(character.EntityPosition, m_ownerStatsComponent);
        ActionResult result = new ActionResult(true, "Attacking!");
        return result;
    }

    public override void UpdateAction()
    {
    }

    protected override void ResolveComponents() {
        foreach (IGameComponent gameComponent in m_gameComponents) {
            switch (gameComponent.GameComponentId) {
                case GameComponentDictionary.STATS_COMPONENT_ID:
                    m_ownerStatsComponent = (StatsComponent)gameComponent;
                    break;
                default:
                    break;
            }
        }
    }
    #endregion
}