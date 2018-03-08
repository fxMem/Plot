using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Script
    {
        public string InternalTitle { get; set; }

        public DateTime Created { get; set; }

        public MultiLangText Title { get; set; }

        public MultiLangText Description { get; set; }

        public List<string> Authors { get; set; }

        public ScriptVersion Version { get; set; }

        public EntityCollection<Chapter, CollectionOneIdFactory<Chapter>> Chapters { get; set; }

        public VariablesCollection Variables { get; set; }

        public EntityCollection<Language, CollectionStringIdFactory<Language>> Languages { get; set; }

        public EntityCollection<Character, CollectionOneIdFactory<Character>> Characters { get; set; }

        public EntityCollection<Resource, CollectionOneIdFactory<Resource>> Resources { get; set; }

        public EntityCollection<ResourceRefCollection, CollectionOneIdFactory<ResourceRefCollection>> ExternalResources { get; set; }

        public EntityId DefaultLanguageId { get; set; }

        public Script()
        {
            Chapters = new EntityCollection<Chapter, CollectionOneIdFactory<Chapter>>();
            Variables = new VariablesCollection();
            Characters = new EntityCollection<Character, CollectionOneIdFactory<Character>>();
            Resources = new EntityCollection<Resource, CollectionOneIdFactory<Resource>>();
            Languages = new EntityCollection<Language, CollectionStringIdFactory<Language>>();
            ExternalResources = new EntityCollection<ResourceRefCollection, CollectionOneIdFactory<ResourceRefCollection>>();
        }

        public Chapter GetFirstChapter()
        {
            return Chapters.OrderBy(c => c.Order).FirstOrDefault();
        }

        public ResourceRef TryGetResource(ResourceId id)
        {
            var collection = ExternalResources.TryGetValue(id.CollectionId);
            if (collection == null)
            {
                return null;
            }

            return collection.References.TryGetValue(id.ReferenceId);
        }
    }
}
