using System.Collections;
using System.Collections.Generic;

namespace Common
{
    public interface IRepository<T, in Q>
    {
        IEnumerable<T> GetElements();
        bool TryGet(Q key, out T element);
        T Get(Q key);
    }

    public interface IRepository<T> : IRepository<T, int> { }
}
