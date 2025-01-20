namespace Entities.Ports
{
    public interface IEntityStaticModel
    {
        string ViewId { get; }
        int TemplateId { get; }
        string EntityForename { get; }
    }
}