using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class CollectionIdFactory<T> : EntityIdFactory where T : Entity
    {
        public EntityDictionary<T> Collection { get; set; }

        public CollectionIdFactory()
        {
        }

        public override EntityId Create(object entity)
        {
            var generciEntity = entity as T;
            if (generciEntity == null)
            {
                throw new ArgumentException($"Cannot create id for type {entity.GetType().FullName} from id factory of type {typeof(T).FullName}");
            }

            return GetNextId(generciEntity);
        }

        protected virtual EntityId GetNextId(T entity)
        {
            throw new NotImplementedException();
        }
    }

    public class CollectionOneIdFactory<T> : CollectionIdFactory<T> where T: Entity
    {
        private double? _lastId;

        public CollectionOneIdFactory()
        {
            
        }

        protected override EntityId GetNextId(T entity)
        {
            if (_lastId == null)
            {
                if (!Collection.Values.Any())
                {
                    _lastId = 0;
                }
                else
                {
                    _lastId = Math.Ceiling(Collection.Values.
                        Select(e => e.Id as OneEntityId).
                        Max(i => i.Id));
                }
                
            }

            _lastId++;
            return new OneEntityId() { Id = _lastId.Value };
        }
    }
}
