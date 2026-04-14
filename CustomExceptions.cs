using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message) : base(message) { }
    }

    public class OverCapacityException : Exception
    {
        public OverCapacityException(string message) : base(message) { }
    }

    public class EmptyStructureException : Exception
    {
        public EmptyStructureException(string message) : base(message) { }
    }

   
}
