using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class ResourceRefCollection: Entity
    {
        public EntityCollection<ResourceRef, CollectionOneIdFactory<ResourceRef>> References { get; set; }

        public ResourceRefCollection()
        {
            References = new EntityCollection<ResourceRef, CollectionOneIdFactory<ResourceRef>>();
        }
    }
}
