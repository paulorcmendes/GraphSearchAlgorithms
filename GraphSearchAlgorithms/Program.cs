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
        static Dictionary<String, Node> graph;
        static void InitGraph() {
            String[] namesOfNodes = { "Arad", "Zerind", "Oradea", "Timisoara",
                                      "Lugoj", "Mehadia", "Drobeta", "Craiova",
                                      "Sibiu", "Fagaras", "Rimnicu", "Pitesti",
                                      "Neamt", "Iasi", "Vaslui", "Bucareste",
                                      "Giurgiu", "Urziceni", "Hirsova", "Eforie"};
            graph = new Dictionary<String, Node>();
            foreach (String name in namesOfNodes)
            {
                graph.Add(name, new Node(name));
            }
            InitEdges();
        }
        static void InitEdges() {

        }
        static void Main(string[] args)
        {
            InitGraph();
            foreach(KeyValuePair<String, Node> entry in graph)
            {
                Console.WriteLine(entry.Value.Name);
            }

            Console.ReadKey();
        }
    }
}
