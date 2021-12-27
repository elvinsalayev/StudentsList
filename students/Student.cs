using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.First
{
    [Serializable]
    internal class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int School { get; set; }
        public string Class { get; set; }


        public override string ToString()
        {
            return $"{Name} {Surname} / {Age} / {Gender} / {School} / {Class}";
        }
    }
}
