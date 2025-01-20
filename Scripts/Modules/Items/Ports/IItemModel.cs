namespace Items.Ports
{
    public interface IItemModel
    {
        IItemStaticData StaticData { get; }
        int Level { get; }
        IItemLevelingData Attributes { get; }
    }
}