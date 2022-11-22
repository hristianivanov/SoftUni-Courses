
namespace CollectionHierarchy.Models
{
    using Interfaces;
    public class AddRemoveCollection : Collection, IAddRemover
    {
        public AddRemoveCollection()
            : base()
        {
        }
        public int Add(string item)
        {
            base.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            int index = base.collection.Count - 1;
            string itemValue = base.collection[index];
            base.collection.RemoveAt(index);
            return itemValue;
        }
    }
}
