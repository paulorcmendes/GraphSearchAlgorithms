using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearchAlgorithms
{
    class Path : Neighbor
    {
        private List<Node> pathToMe;
        public Path(Node node, int cost) : base(node, cost)
        {
            pathToMe = new List<Node>();
        }

        public List<Node> PathToMe {
            get
            {
                return pathToMe;
            }
            set
            {
                pathToMe = value;
            }
        }
    }
}
