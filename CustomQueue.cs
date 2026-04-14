using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SmartLogisticsDelieverySystem
{
    public class CustomQueue<T> : IQueuable<T>
    {
        private T[] myarray;
        private int count;


        //constructor 
        public CustomQueue(int capacity)
        {
            if (capacity <= 0)

                throw new ArgumentException("Capacity must be greater than zero.");

            myarray = new T[capacity];
            count = 0;
        }


        //enqueue
        //[n1,n2,n3]
        public void Enqueue(T item)
        {
            //check if the array is full
            if (count == myarray.Length)

            {
                Console.WriteLine("Queue is full. Cannot enqueue item.");
                return;

            }
            myarray[count] = item;
            count++;
        }


        //[n1,n2,n3] = > Dequeue() => n1 => [null,n2,n3]
        public T Dequeue()
        {
            if (count == 0)
            {
                throw new Exception("Queue is empty. Cannot dequeue item.");
            }
            T item = myarray[0];
            //shift all the elements
            for (int i = 1; i < count; i++)
            {
                myarray[i - 1] = myarray[i];
            }
            myarray[count - 1] = default(T);   //Clear the last element
            count--;
            return item;
        }
        public T Peek()
        {
            if (count == 0)
            {
                throw new Exception("Queue is empty. Cannot peek item.");
            }
            return myarray[0];
        }

        public bool IsEmpty()
        { 
            return count == 0;
        }
    }
}

