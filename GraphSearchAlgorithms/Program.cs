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
            graph["Arad"].Neighbors.Add(new Neighbor(graph["Sibiu"], 140));
            graph["Arad"].Neighbors.Add(new Neighbor(graph["Timisoara"], 118));
            graph["Arad"].Neighbors.Add(new Neighbor(graph["Zerind"], 75));

            graph["Zerind"].Neighbors.Add(new Neighbor(graph["Arad"], 75));
            graph["Zerind"].Neighbors.Add(new Neighbor(graph["Oradea"], 71));

            graph["Oradea"].Neighbors.Add(new Neighbor(graph["Sibiu"], 151));
            graph["Oradea"].Neighbors.Add(new Neighbor(graph["Zerind"], 71));

            graph["Timisoara"].Neighbors.Add(new Neighbor(graph["Arad"], 118));
            graph["Timisoara"].Neighbors.Add(new Neighbor(graph["Lugoj"], 111));

            graph["Lugoj"].Neighbors.Add(new Neighbor(graph["Mehadia"], 70));
            graph["Lugoj"].Neighbors.Add(new Neighbor(graph["Timisoara"], 111));

            graph["Mehadia"].Neighbors.Add(new Neighbor(graph["Drobeta"], 75));
            graph["Mehadia"].Neighbors.Add(new Neighbor(graph["Lugoj"], 70));

            graph["Drobeta"].Neighbors.Add(new Neighbor(graph["Craiova"], 120));
            graph["Drobeta"].Neighbors.Add(new Neighbor(graph["Mehadia"], 75));

            graph["Craiova"].Neighbors.Add(new Neighbor(graph["Drobeta"], 120));
            graph["Craiova"].Neighbors.Add(new Neighbor(graph["Pitesti"], 138));
            graph["Craiova"].Neighbors.Add(new Neighbor(graph["Rimnicu"], 146));

            graph["Sibiu"].Neighbors.Add(new Neighbor(graph["Arad"], 140));
            graph["Sibiu"].Neighbors.Add(new Neighbor(graph["Fagaras"], 99));
            graph["Sibiu"].Neighbors.Add(new Neighbor(graph["Oradea"], 151));
            graph["Sibiu"].Neighbors.Add(new Neighbor(graph["Rimnicu"], 80));

            graph["Fagaras"].Neighbors.Add(new Neighbor(graph["Bucareste"], 211));
            graph["Fagaras"].Neighbors.Add(new Neighbor(graph["Sibiu"], 99));

            graph["Rimnicu"].Neighbors.Add(new Neighbor(graph["Craiova"], 146));
            graph["Rimnicu"].Neighbors.Add(new Neighbor(graph["Pitesti"], 97));
            graph["Rimnicu"].Neighbors.Add(new Neighbor(graph["Sibiu"], 80));

            graph["Pitesti"].Neighbors.Add(new Neighbor(graph["Bucareste"], 101));
            graph["Pitesti"].Neighbors.Add(new Neighbor(graph["Craiova"], 138));
            graph["Pitesti"].Neighbors.Add(new Neighbor(graph["Rimnicu"], 97));

            graph["Neamt"].Neighbors.Add(new Neighbor(graph["Iasi"], 87));

            graph["Iasi"].Neighbors.Add(new Neighbor(graph["Neamt"], 87));
            graph["Iasi"].Neighbors.Add(new Neighbor(graph["Vaslui"], 92));

            graph["Vaslui"].Neighbors.Add(new Neighbor(graph["Iasi"], 92));
            graph["Vaslui"].Neighbors.Add(new Neighbor(graph["Urziceni"], 142));

            graph["Bucareste"].Neighbors.Add(new Neighbor(graph["Fagaras"], 211));
            graph["Bucareste"].Neighbors.Add(new Neighbor(graph["Giurgiu"], 90));
            graph["Bucareste"].Neighbors.Add(new Neighbor(graph["Pitesti"], 101));
            graph["Bucareste"].Neighbors.Add(new Neighbor(graph["Urziceni"], 85));

            graph["Giurgiu"].Neighbors.Add(new Neighbor(graph["Bucareste"], 90));

            graph["Urziceni"].Neighbors.Add(new Neighbor(graph["Bucareste"], 85));
            graph["Urziceni"].Neighbors.Add(new Neighbor(graph["Hirsova"], 98));
            graph["Urziceni"].Neighbors.Add(new Neighbor(graph["Vaslui"], 142));

            graph["Hirsova"].Neighbors.Add(new Neighbor(graph["Eforie"], 86));
            graph["Hirsova"].Neighbors.Add(new Neighbor(graph["Urziceni"], 98));

            graph["Eforie"].Neighbors.Add(new Neighbor(graph["Hirsova"], 86));
        }
        static void Main(string[] args)
        {
            InitGraph();
            List<Neighbor> border = new List<Neighbor>();

            border.Add(new Neighbor(graph["Fagaras"], 2));
            border.Add(new Neighbor(graph["Eforie"], 7));
            border.Add(new Neighbor(graph["Hirsova"], 4));
            border.Add(new Neighbor(graph["Bucareste"], 2));
            border.Add(new Neighbor(graph["Timisoara"], 1));
            border.Sort();
            foreach (Neighbor entry in border)
            {
                Console.Write(entry.Node.Name+": "+ entry.Cost);
                
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
