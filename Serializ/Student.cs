using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializ
{
    public class Student
    {
        public Person Person { get; set; }
        public string uniName { get; set; }
        public int groupId { get; set; }
        public List<string> Lessons { get; set; }   
    }
}
