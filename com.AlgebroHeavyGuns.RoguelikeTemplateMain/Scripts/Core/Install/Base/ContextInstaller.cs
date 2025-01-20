using System.Collections;
using UnityEngine;


namespace Core.Install.Base
{
    public abstract class ContextInstaller : MonoBehaviour
    {
        private void Awake()
        {
            DefineReferences();
            Install();
            Initialize();
        }

        private void Start()
        {
            PreStart();
            StartSceneExecution();
        }

        private void Update()
        {
            Tick(Time.deltaTime);
        }

        private void OnDisable()
        {
            StopSceneExecution();
            Dispose();
            Uninstall();
        }
        
        protected virtual void PreStart(){}

        protected abstract void DefineReferences();
        protected abstract void Install();
        protected abstract void Uninstall();
        protected abstract void Initialize();
        protected abstract void Dispose();
        protected abstract void Tick(float deltaTime);
        protected abstract void StartSceneExecution();
        protected abstract void StopSceneExecution();

    }
}