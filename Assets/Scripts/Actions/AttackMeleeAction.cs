using System.Collections.Generic;

public sealed class AttackMeleeAction : Action
{
    public override List<string> RequiredGameComponentsIds { get => 
            new() { 
                GameComponentDictionary.STATS_COMPONENT_ID, 
                GameComponentDictionary.WIELD_ITEMS_COMPONENT_ID 
            }; }

    public override string ActionId { get => ActionsDictionary.ATTACK_ACTION_ID; }

    private MeleeWeapon MeleeWeapon;

    private StatsComponent m_ownerStatsComponent;
    private WieldItemsComponent m_wieldItemsComponent;

    #region Action Implementation
    public override ActionResult ExecuteAction(ICharacter character, WorldState worldState) {
        //charcter.Attack()
        MeleeWeapon.Attack(character, worldState);
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
                case GameComponentDictionary.WIELD_ITEMS_COMPONENT_ID:
                    m_wieldItemsComponent = (WieldItemsComponent)gameComponent;
                    //MeleeWeapon = m_wieldItemsComponent.Hands;
                    break;
                default:
                    break;
            }
        }
    }
    #endregion
}