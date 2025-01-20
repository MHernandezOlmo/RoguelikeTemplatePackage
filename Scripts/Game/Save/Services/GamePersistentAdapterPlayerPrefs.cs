using System;
using Core.Save.Ports;
using UnityEngine;

namespace Game.Save.Services
{
    public class GamePersistentAdapterPlayerPrefs : IPersistenceAdapter
    {
        public void Save<T>(string identifier, T obj)
        {
            var jsonString = JsonUtility.ToJson(obj);
            PlayerPrefs.SetString(identifier, jsonString);
            PlayerPrefs.Save();
        }

        public T Load<T>(string identifier)
        {
            var savedString = PlayerPrefs.GetString(identifier, string.Empty);
            if (string.IsNullOrEmpty(savedString)) return default;
            
            var jsonResult = JsonUtility.FromJson<T>(savedString);
            return jsonResult;
        }

        public bool HasSavedFile(string identifier)
        {
            return PlayerPrefs.HasKey(identifier);
        }

        public void RemoveFile(string identifier)
        {
            PlayerPrefs.DeleteKey(identifier);
        }

        public void Initialize()
        {

        }

        public void Dispose()
        {

        }
    }
}