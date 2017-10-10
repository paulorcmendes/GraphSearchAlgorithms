using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearchAlgorithms
{
	//Class Node
    class Node
    {
        private List<Neighbor> neighbors;
        private String name;
        private int expectation;

        public Node(String name)
        {
            this.Name = name;
            this.neighbors = new List<Neighbor>();
            this.expectation = 0;
        }
        public Node(String name, int expectation)
        {
            this.Name = name;
            this.neighbors = new List<Neighbor>();
            this.Expectation = expectation;
        }
        public int Expectation {
            get
            {
                return expectation;
            }
            set
            {
                expectation = value;
            }
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
