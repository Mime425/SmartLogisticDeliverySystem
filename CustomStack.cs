using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
    public class CustomStack<T>
    {
        private T[] arr;
        private int top;
        private int capacity;

        //constructor to initialize the stack

        public  CustomStack(int size)

        {
            capacity = size;
            arr = new T[capacity];
            top = -1;
        }

        // methods for stack
        //Push

        public void Push(T value)

        {

            if (top == capacity - 1)

            {

                Console.WriteLine("Stack os full");

                return;

            }
            top++;
            arr[top] = value;

        }


        //Pop
        public T Pop()
        {
            if (IsEmpty())

            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            T value = arr[top];
            top--;

            return value;
        }


        //Peek
        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            return arr[top];
        }

        //method to return if the array is empty or not
        public bool IsEmpty()
        {
            return top == -1;
        }
    }
}