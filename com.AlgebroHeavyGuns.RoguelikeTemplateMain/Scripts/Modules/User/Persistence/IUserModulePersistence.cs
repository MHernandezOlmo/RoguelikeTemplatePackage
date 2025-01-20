namespace User.Persistence
{
    public interface IUserModulePersistence
    {
        UserPersistentData GeneratePersistentData();
        void LoadPersistentData(UserPersistentData data);
        void ResetPersistentData();
    }
    
}
