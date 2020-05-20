using Stack_App.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Stack_App
{
    public class Stack<T> 
    {
        public static int _size;
        private T[] values = new T[2];
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
    }
}
