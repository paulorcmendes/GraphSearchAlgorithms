using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearchAlgorithms
{
    class Node
    {
        private String name;

        public Node(String name)
        {
            this.Name = name;
        }
        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
    }
}
