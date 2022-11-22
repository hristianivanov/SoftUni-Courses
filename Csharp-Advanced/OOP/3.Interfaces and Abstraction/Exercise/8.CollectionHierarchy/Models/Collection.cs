
namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;
    public abstract class Collection
    {
        protected List<string> collection;

        public Collection()
        {
            this.collection = new List<string>();
        }
    }
}
