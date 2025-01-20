using Core.Save.Ports;

namespace Core.Save
{
    public class PersistentService<T> : ISaveService, ILoadService where T : new()
    {
        private bool isDirty = false;

        private IPersistentRepository<T> persistentRepository;
        private IPersistenceAdapter persistenceAdapter;

        private static string SAVE_FILE_NAME = "SaveFile";

        public void SetData(IPersistentRepository<T> repository, IPersistenceAdapter adapter)
        {
            persistentRepository = repository;
            persistenceAdapter = adapter;
        }

        public void Initialize()
        {
            persistenceAdapter.Initialize();
        }

        public void Tick(float deltaTime)
        {
            if (!isDirty) return;
            
            SaveData();
        }

        public void Dispose()
        {
            persistenceAdapter.Dispose();
        }
        
        public void Save()
        {
            isDirty = true;
        }

        public void Load()
        {
            T data;
            if (persistenceAdapter.HasSavedFile(SAVE_FILE_NAME))
            {
                data = persistenceAdapter.Load<T>(SAVE_FILE_NAME);
                persistentRepository.SetLoadedData(data);
            }
            else
            {
                data = new T();
                persistentRepository.SetLoadedData(data);
                SaveData(); //Force data file creation
            }
        }
        
        public void RemoveSavedData()
        {
            persistenceAdapter.RemoveFile(SAVE_FILE_NAME);
        }

        public void ResetData()
        {
            persistentRepository.ResetData();
        }

        private void SaveData()
        {
            var data = persistentRepository.GetPersistentData();
            persistenceAdapter.Save(SAVE_FILE_NAME, data);
            isDirty = false;
        }
    }
}