namespace User.Ports
{
    public interface IUserDataModel
    {
        bool HasActiveAdventure { get; }
        int Gold { get; }
    }
}