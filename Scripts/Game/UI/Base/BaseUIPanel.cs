using System;
using Core.UI;
using UnityEngine;

namespace Game.UI.Base
{
    public abstract class BaseUIPanel : CoreUIPanel
    {
        protected override void ShowInstantSetValues()
        {
            content.localScale = Vector3.one;
        }
    
        protected override void HideInstantSetValues()
        {
            content.localScale = Vector3.zero;
        }
        
        protected override void ShowAnimation(Action onFinished)
        {
            //<Create tween or showing default animation>  Should use showAnimationTime, showCurve and invoke onFinished on completed)
        }
    
        protected override void HideAnimation(Action onFinished)
        {
            //<Create tween or showing default animation>  Should use hideAnimationTime, hideCurve and invoke onFinished on completed)
        }
    }
}