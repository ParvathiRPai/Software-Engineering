﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class MyClass
    {
        ~MyClass()
        {
            Console.WriteLine("In the MyClass Finalizer!!!!111");
        }
    }
}