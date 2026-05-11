using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogisticsDelieverySystem
{
    // this is an interface for file handling
    // it saves and loads data
     interface IFileHanlder
    {
        //saves data into file
        void Save(string path);

        //loads data from file
        void Load(string path);

    }
}
