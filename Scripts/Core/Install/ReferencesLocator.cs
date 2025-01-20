using System;
using Core.Install.Base;
using UnityEngine.Assertions;
using System.Collections.Generic;
using Core.Install.Ports;

namespace Core.Install
{
    public class ReferencesLocator : IReferencesRepository
    {
        public static ReferencesLocator Instance => instance ??= new ReferencesLocator();
        private static ReferencesLocator instance;

        private Dictionary<Type, object> References { get; } = new ();

        private ReferencesLocator(){}

        public bool HasReference<T>()
        {
            var type = typeof(T);
            return References.ContainsKey(type);
        }

        public bool RemoveReference<T>() => References.Remove(typeof(T));
        public void AddReference<T>(T reference)
        {
            var type = typeof(T);
            Assert.IsFalse(References.ContainsKey(type), $"Reference of {type} already registered!");
            References.Add(type, reference);
        }

        public T GetReference<T>()
        {
            var type = typeof(T);
            return References.TryGetValue(type, out var reference)
                ? (T) reference
                : throw new Exception($"Reference of {type} not found! You should use HasReference if you only want to check if it exists.");
        }

        public void Clear()
        {
            References.Clear();
        }
    }
}