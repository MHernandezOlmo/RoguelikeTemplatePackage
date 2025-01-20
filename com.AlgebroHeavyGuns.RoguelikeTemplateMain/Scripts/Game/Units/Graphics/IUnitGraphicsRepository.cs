using System.Collections.Generic;
using Entities.Ports;
using UnityEngine;

namespace Game.Units.Graphics
{
    public interface IUnitGraphicsRepository: IEntityViewTemplatesRepository
    {
        bool TryGetUnitGenericImage(string key, out Sprite image);
        IEnumerable<Sprite> GetAllUnitGenericImages();
    }
}
