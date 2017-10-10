using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearchAlgorithms
{
    public enum CATEGORY{BREADTH_FIRST, UNIFORM_COST, A_STAR}
    class Path : Neighbor, IComparable<Path>
    {
        private List<Node> pathToMe;
        private CATEGORY myCategory;
        public Path(Node node, int cost) : base(node, cost)
        {
            pathToMe = new List<Node>();
            MyCategory = CATEGORY.BREADTH_FIRST;
        }
        public Path(Node node, int cost, CATEGORY myCategory) : base(node, cost)
        {
            pathToMe = new List<Node>();
            MyCategory = myCategory;
        }

        public List<Node> PathToMe 
        {
            get
            {
                return pathToMe;
            }
            set
            {
                pathToMe = value;
            }
        }
        public CATEGORY MyCategory
        {
            get
            {
                return myCategory;
            }
            set
            {
                myCategory = value;
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

        public int CompareTo(Path other)
        {   
            if(myCategory == CATEGORY.A_STAR)
            {
                int v1 = Cost+Node.Expectation;
                int v2 = other.Cost + other.Node.Expectation;

                return v1.CompareTo(v2);
            }         
            return Cost.CompareTo(other.Cost);
        }
    }
}
