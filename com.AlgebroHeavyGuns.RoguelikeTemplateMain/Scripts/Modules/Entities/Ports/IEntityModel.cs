namespace Entities.Ports
{
    public interface IEntityModel
    {
        IEntityStaticModel Static { get; }
        bool TryGetCurrentAttribute(int attributeKey, out float value);
        bool TryGetMaxAttribute(int attributeKey, out float value);
        IEntityAlteredStateManager AlteredStateManager { get; }
        IEntityStatistic Statistic { get; }
        
    }
}