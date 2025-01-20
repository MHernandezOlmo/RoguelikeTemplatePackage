namespace User.Persistence
{
    public class UserModulePersistence : IUserModulePersistence
    {
        private readonly UserDataSystem system;
        
        public UserModulePersistence(UserDataSystem system)
        {
            this.system = system;
        }


        public UserPersistentData GeneratePersistentData()
        {
            return system.GetPersistentData();
        }

        public void LoadPersistentData(UserPersistentData data)
        {
            system.LoadPersistentData(data);
        }

        public void ResetPersistentData()
        {
            system.ResetPersistentData();
        }
    }
}