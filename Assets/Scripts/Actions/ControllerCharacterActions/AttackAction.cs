public sealed class AttackAction : Action
{
    public AttackAction() : base(ActionsDictionary.ATTACK_ACTION_ID) { }

    #region InputAction Implementation
    public override void ExecuteAction(ICharacter character) {
        //charcter.Attack()
    }
    #endregion
}