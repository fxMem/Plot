using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public interface IEntityCollection<T>: ICollection<T> where T: Entity
    {
        T this[EntityId id] { get; }

        T TryGetValue(EntityId id);

        bool Contains(EntityId id);

        void Remove(EntityId id);
    }
}
