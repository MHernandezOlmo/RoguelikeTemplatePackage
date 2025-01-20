using UnityEngine;

namespace Game.Battle.Services
{
    public class BattleTriggerActionApplicator
    {
        public void SetData()
        {
            
        }
        
        public void ApplyTrigger(string skillId)
        {
            Debug.Log("Applied trigger action skill : " + skillId);
        }
    }
}