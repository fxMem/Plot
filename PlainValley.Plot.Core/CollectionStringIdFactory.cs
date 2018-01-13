using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class CollectionStringIdFactory<T>: CollectionIdFactory<T> where T : Entity
    {
        protected override EntityId GetNextId(T entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
            {
                throw new ArgumentException($"Cannot create string Id for entity of type {typeof(T).FullName} cause Name of entity is not specified!");
            }

            return new StringEntityId(entity.Name);
        }
    }
}
