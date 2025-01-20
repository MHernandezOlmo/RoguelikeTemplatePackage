using System.Collections.Generic;
using UnityEngine;

namespace Game.Items.Graphics
{
    public interface IItemGraphicsRepository
    {
        bool TryGetItemGenericImage(string key, out Sprite image);
        IEnumerable<Sprite> GetAllItemsGenericImages();
    }
}