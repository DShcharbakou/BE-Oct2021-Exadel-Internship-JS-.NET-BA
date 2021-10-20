using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TopicStack
    {
        public int TopicID {get; set;}
        public int StackID {get; set;}

        public Stack Stack { get; set; }
        public Topic Topic { get; set; }
    }
}
