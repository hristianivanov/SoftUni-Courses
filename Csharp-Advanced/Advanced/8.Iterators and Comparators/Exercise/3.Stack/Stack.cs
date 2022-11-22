using System;
using System.Collections;
using System.Collections.Generic;

namespace _3.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int LENGHT = 4;
        private T[] arr ;
        private int index;

        public Stack()
        {
            arr = new T[LENGHT];
        }

        public void Push(T element)
        {
            if (index >= arr.Length)
            {
                Resize();
            }
            arr[index] = element;
            index++;
        }

        public void Pop()
        {
            if (index == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            --index;
        }

        private void Resize()
        {
            T[] temp = new T[arr.Length * 2];
            Array.Copy(arr, 0, temp, 0, arr.Length);
            //for (int i = 0; i < index; i++)
            //{
            //    temp[i] = arr[i];
            //}
            arr = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = index - 1; i >= 0; i--)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
