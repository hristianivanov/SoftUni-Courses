using System;
using System.Collections.Generic;
using System.Text;

namespace _5.StackofStrings
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => this.Count == 0;
        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var item in collection)
                this.Push(item);
        }
    }
}
