using System.Collections.Generic;

namespace Map.Ports
{
    public interface IMapsStaticRepository
    {
        public IEnumerable<IMapStaticModel> MapStaticModels { get; }
    }
}