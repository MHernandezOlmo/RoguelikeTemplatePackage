using System;

namespace User.Persistence
{
    [Serializable]
    public class UserPersistentData
    {
        public bool hasActiveAdventure;
        public int userGold;
        
        public UserInventoryPersistentData inventory = new();
    }
}