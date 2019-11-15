using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Student() : this ("unknown", 18)
        {

        }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
