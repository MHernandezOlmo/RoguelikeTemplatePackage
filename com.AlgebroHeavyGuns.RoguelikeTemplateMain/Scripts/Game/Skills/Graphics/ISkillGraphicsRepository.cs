using System.Collections.Generic;
using UnityEngine;

namespace Game.Skills.Graphics
{
    public interface ISkillGraphicsRepository
    {
        bool TryGetSkillImage(string key, out Sprite image);
        IEnumerable<Sprite> GetAllSkillImages();
    }
}
