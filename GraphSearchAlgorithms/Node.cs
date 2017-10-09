using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearchAlgorithms
{
    class Node
    {
        private List<Neighbor> neighbors;
        private String name;

        public Node(String name)
        {
            this.Name = name;
            this.neighbors = new List<Neighbor>();
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
        public List<Neighbor> Neighbors
        {
            get
            {
                return this.neighbors;
            }
        }
        public override String ToString()
        {
            return Name;
        }
    }
}
