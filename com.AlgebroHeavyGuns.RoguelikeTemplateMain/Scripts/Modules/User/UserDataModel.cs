using User.Ports;

namespace User
{
    public class UserDataModel : IUserDataModel
    {
        public bool HasActiveAdventure { get; set; }
        public int  Gold { get; set; }
    }
}