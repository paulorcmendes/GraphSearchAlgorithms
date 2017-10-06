using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearchAlgorithms
{
    class Program
    {
        static Dictionary<String, Node> nodes;
        static void InitGraph() {
            String[] namesOfNodes = { "Arad", "Zerind", "Oradea", "Timisoara",
                                      "Lugoj", "Mehadia", "Drobeta", "Craiova",
                                      "Sibiu", "Fagaras", "Rimnicu", "Pitesti",
                                      "Neamt", "Iasi", "Vaslui", "Bucareste",
                                      "Giurgiu", "Urziceni", "Hirsova", "Eforie"};
            nodes = new Dictionary<String, Node>();
            foreach(String name in namesOfNodes)
            {
                nodes.Add(name, new Node(name));
            }
        }
        static void Main(string[] args)
        {
            InitGraph();
            foreach(KeyValuePair<String, Node> entry in nodes)
            {
                Console.WriteLine(entry.Value.Name);
            }

            Console.ReadKey();
        }
    }
}
