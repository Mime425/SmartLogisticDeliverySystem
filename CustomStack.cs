using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
    //Custom Stack
    public class CustomStack<T>
    {
        private T[] arr;
        private int top;
        private int capacity;

        //constructor to initialize the stack

        public  CustomStack(int size)

        {
            capacity = size;
            arr = new T[capacity]; // new array is created
            top = -1;  // the stack is empty
        }

        // methods for stack
        //Push, which adds the item on top of the stack

        public void Push(T value)

        {

            if (top == capacity - 1) // check if stack is full

            {

                Console.WriteLine("Stack is full");

                return;

            }
            top++;                 // we move to the next postion 
            arr[top] = value;    // and here we put the value

        }


        //Pop
        // removes and returns the top element 
        public T Pop()
        {
            if (IsEmpty())

            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            T value = arr[top];  //gets top value 
            top--;

            return value;
        }


        //Peek
        //this returns top item without removing it 
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