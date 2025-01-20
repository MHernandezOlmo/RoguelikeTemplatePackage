using Core.Save.Ports;
using User.Ports;

namespace Game.User
{
    public class UserEventsEmitter : IUserDataEventsEmitter
    {
        private ISaveService saveService;

        public void SetData(ISaveService saveService)
        {
            this.saveService = saveService;
        }

        public void OnUserDataChanged()
        {
            saveService.Save();
        }
    }
}