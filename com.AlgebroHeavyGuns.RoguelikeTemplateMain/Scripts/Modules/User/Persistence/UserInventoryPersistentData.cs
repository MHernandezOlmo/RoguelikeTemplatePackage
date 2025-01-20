using System;
using System.Collections.Generic;

namespace User.Persistence
{
    [Serializable]
    public class UserInventoryPersistentData
    {
        public UserInventoryFieldPersistentData[] inventoryData = Array.Empty<UserInventoryFieldPersistentData>();
    }
}