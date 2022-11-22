
namespace CollectionHierarchy.Models
{
    using Interfaces;
    public class AddCollection : Collection, IAddder
    {
        public AddCollection()
            : base()
        {
        }

        public int Add(string item)
        {
            base.collection.Add(item);
            return base.collection.Count - 1;
        }
    }
}
