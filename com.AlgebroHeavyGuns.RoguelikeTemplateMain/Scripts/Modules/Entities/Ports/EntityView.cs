using UnityEngine;

namespace Entities.Ports
{
    public abstract class EntityView<TListener> : EntityView
    {
        protected TListener Listener { get; private set; }

        public void SetListener(TListener listener) => Listener = listener;

    }

    public abstract class EntityView : MonoBehaviour
    {
        public Vector3 WorldPosition => transform.position;
        public Quaternion GlobalRotation => transform.rotation;
        public Quaternion LocalRotation => transform.localRotation;
        public Vector3 Forward => transform.forward;
        public Vector3 Right => transform.right;
        public Vector3 Up => transform.up;
    }
}