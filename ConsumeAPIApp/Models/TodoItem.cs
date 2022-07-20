using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeAPIApp.Models
{
    public class TodoItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isComplete { get; set; }

        public override string ToString()
        {
            return $"{id, -10} {name, -50} {isComplete, -10} \n";
        }
    }
}
