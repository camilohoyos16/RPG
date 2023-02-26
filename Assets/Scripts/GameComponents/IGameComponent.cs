public interface IGameComponent
{
    public string GameComponentId { get; }

    public void InitComponent();
    public void UpdateComponent(WorldState worldState);
}
