

namespace CollectionHierarchy.Models
{
    using Interfaces;
    public class MyList : Collection, IMyList
    {
        public MyList()
            : base()
        {
        }

        public int Used => base.collection.Count;

        public int Add(string item)
        {
            base.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string itemValue = base.collection[0];
            base.collection.RemoveAt(0);
            return itemValue;
        }
    }
}
