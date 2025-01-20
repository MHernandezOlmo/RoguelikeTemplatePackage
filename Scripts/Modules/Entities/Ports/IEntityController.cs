namespace Entities.Ports
{
    public interface IEntityController
    {
        int Id { get; }
        EntityView View { get; }
        IEntityModel Model { get; }
        bool IsAlive { get; }
        uint Team { get; }
        
        
        void Initialize();
        void Tick(float deltaTime);
        void ApplyHealthVariation(float healthVariation);
    }
}