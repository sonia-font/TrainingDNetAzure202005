using Stack_App.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Stack_App
{
    public class Stack<T> : IEnumerable<T>
    {
        public static int _size;
        private T[] values = new T[10];
        private int top = 0;

        /*public Stack(int size)
        {
            _size = size;
        }*/

        public void Push(T t)
        {
            values[top] = t;
            top++;
        }
        public T Pop()
        {
            top--;
            return values[top];
        }

        // This method implements the GetEnumerator method. It allows
        // an instance of the class to be used in a foreach statement.
        public IEnumerator<T> GetEnumerator()
        {
            for (int index = top - 1; index >= 0; index--)
            {
                yield return values[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> TopToBottom
        {
            get { return this; }
        }

        public IEnumerable<T> BottomToTop
        {
            get
            {
                for (int index = 0; index <= top - 1; index++)
                {
                    yield return values[index];
                }
            }
        }

        public IEnumerable<T> TopN(int itemsFromTop)
        {
            // Return less than itemsFromTop if necessary.
            int startIndex = itemsFromTop >= top ? 0 : top - itemsFromTop;

            for (int index = top - 1; index >= startIndex; index--)
            {
                yield return values[index];
            }
        }

    }
}
