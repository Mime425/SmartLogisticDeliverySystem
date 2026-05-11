using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
     public interface IQueuable<T>
    {
        // adds item to the queue at the end
        void Enqueue(T item);

        // this removes and returns the first item from queue
        T Dequeue();
        // this looks at the first item without removing it 
        T Peek();


        bool IsEmpty();
    }
}
