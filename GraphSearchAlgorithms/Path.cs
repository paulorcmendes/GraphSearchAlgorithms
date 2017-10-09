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

        private string PathToString(List<Node> path)
        {
            string msg = "";
            foreach (Node node in path)
            {
                msg += "-->" + node.Name;
            }
            return msg;
        }

        public override string ToString()
        {
            return PathToString(PathToMe) + " with cost: " + base.Cost;
        }
    }
}
