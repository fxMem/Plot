using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class EntityCollection<T, TIdFactory> : IEntityCollection<T> where T : Entity where TIdFactory: CollectionIdFactory<T>, new()
    {
        [JsonIgnore]
        private TIdFactory _idFactory;

        [JsonIgnore]
        private TIdFactory IdFactory
        {
            get
            {
                if (_idFactory == null)
                {
                    _idFactory = new TIdFactory
                    {
                        Collection = _data
                    };
                }

                return _idFactory;
            }
        }

        public int Count => _data.Values.Count;

        public bool IsReadOnly => false;

        [JsonProperty]
        private EntityDictionary<T> _data;

        public EntityCollection()
        {
            _data = new EntityDictionary<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[EntityId id]
        {
            get
            {
                var result = TryGetValue(id);
                if (result == null)
                {
                    throw new ArgumentException($"Entity {id} of type {typeof(T).FullName} not found!");
                }

                return result;
            }
        }

        public T TryGetValue(EntityId id)
        {
            if (id == null)
            {
                return null;
            }

            T result;
            _data.TryGetValue(id, out result);
            return result;
        }

        public bool Contains(EntityId id)
        {
            return _data.ContainsKey(id);
        }

        public void Add(T entity)
        {
            if (entity.Id != null && _data.ContainsKey(entity.Id))
            {
                throw new ArgumentException($"Entity with key = {entity.Id} already exists in collection!");
            }

            if (entity.Id == null)
            {
                entity.Id = IdFactory.Create(entity);
            }

            _data[entity.Id] = entity;
        }

        public void Remove(EntityId id)
        {
            _data.Remove(id);
        }

        public void ChangeId(EntityId oldId)
        {
            var entity = this[oldId];
            Remove(oldId);

            entity.Id = IdFactory.Create(entity);
            Add(entity);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            return _data.ContainsKey(item.Id);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            Remove(item.Id);
            return true;
        }
    }
}
