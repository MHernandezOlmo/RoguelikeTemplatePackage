using System;
using UnityEngine;

namespace Core.UI
{
    public abstract class CoreUIPanel : MonoBehaviour
    {
        [Header("Base Settings")] [SerializeField]
        protected Transform content;

        [SerializeField] protected float showAnimationTime;
        [SerializeField] protected float hideAnimationTime;
        [SerializeField] protected AnimationCurve showCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] protected AnimationCurve hideCurve = AnimationCurve.Linear(0, 0, 1, 1);

        public virtual void Show(bool instantly = true, Action onFinished = null)
        {
            if (gameObject.activeSelf)
            {
                onFinished?.Invoke();
                return;
            }

            //<kill tween if created>

            gameObject.SetActive(true);

            if (instantly)
            {
                ShowInstantSetValues();
                onFinished?.Invoke();
            }
            else
            {
                ShowAnimation(onFinished);
            }
        }

        public virtual void Hide(bool instantly = true, Action onFinished = null)
        {
            if (!gameObject.activeSelf)
            {
                onFinished?.Invoke();
                return;
            }

            //<kill tween if created>

            if (instantly)
            {
                HideInstantSetValues();
                HideClosedCall();
            }
            else
            {
                HideAnimation(HideClosedCall);
            }

            void HideClosedCall()
            {
                gameObject.SetActive(false);
                onFinished?.Invoke();
            }
        }

        protected abstract void ShowInstantSetValues();
        protected abstract void HideInstantSetValues();
        protected abstract void ShowAnimation(Action onFinished);
        protected abstract void HideAnimation(Action onFinished);
    }
}

