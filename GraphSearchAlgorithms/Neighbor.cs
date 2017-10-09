using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearchAlgorithms
{
    class Neighbor: IComparable<Neighbor>
    {
        private Node node;
        private int cost;

        public Neighbor(Node node, int cost)
        {
            Node = node;
            Cost = cost;
        }

        public Node Node
        {
            get
            {
                return this.node;
            }
            set
            {
                this.node = value;
            }
     
        }

        public int Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                this.cost = value;
            }
        }

        public int CompareTo(Neighbor other)
        {
            return this.cost.CompareTo(other.cost);
        }
    }
}
