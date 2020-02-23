using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDemo
{
    class Stack<T>
    {
        readonly int MAX_SIZE;
        int top = -1;

        public int Size { get; set;}

        readonly T[] stack;

        public Stack(int size)
        {
            MAX_SIZE = size;
            stack = new T[MAX_SIZE];
        }

  public int Push(T item)
        {
            if (top == MAX_SIZE - 1)
            {
                return -1;
            }
            else
            {
                top = top + 1;
                stack[top] = item;
            }
            return 0;
        } 
        public T Pop()
        {
            T RemovedItem;
            T temp = default(T);
            if(!(top <= -1))
            {
                RemovedItem = stack[top];
                top = top - 1;
                return RemovedItem;
            }
            return temp;
        }

        public T[] Get()
        {
            T[] Items = new T[top + 1];
            Array.Copy(stack, 0, Items, 0, top + 1);
            return Items;
        }
    }
}
