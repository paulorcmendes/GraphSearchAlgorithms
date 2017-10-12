using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphSearchAlgorithms
{
    class Program
    {
        static Dictionary<String, Node> graph;
        static void InitGraph() 
        {
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
            SetExpectations();
            InitEdges();
        }
        static void InitEdges() 
        {
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

        static void SetExpectations()
        {
            graph["Arad"].Expectation = 366;
            graph["Bucareste"].Expectation = 0;
            graph["Craiova"].Expectation = 160;
            graph["Drobeta"].Expectation = 242;
            graph["Eforie"].Expectation = 161;
            graph["Fagaras"].Expectation = 176;
            graph["Giurgiu"].Expectation = 77;
            graph["Hirsova"].Expectation = 151;
            graph["Iasi"].Expectation = 226;
            graph["Lugoj"].Expectation = 244;
            graph["Mehadia"].Expectation = 241;
            graph["Neamt"].Expectation = 234;
            graph["Oradea"].Expectation = 380;
            graph["Pitesti"].Expectation = 100;
            graph["Rimnicu"].Expectation = 193;
            graph["Sibiu"].Expectation = 253;
            graph["Timisoara"].Expectation = 329;
            graph["Urziceni"].Expectation = 80;
            graph["Vaslui"].Expectation = 199;
            graph["Zerind"].Expectation = 374;
        }
        
        static void Main(string[] args)
        {
            Path path;
            InitGraph();

            Console.WriteLine("\nBFS:");
            path = GraphSearch.BreadthFirstSearch(graph["Arad"], graph["Bucareste"]);
            if (path != null)
            {
                Console.WriteLine(path);
            }
            else
            {
                Console.WriteLine("Path not found :(");
            }

            Console.WriteLine("\nUniform Cost:");
            path = GraphSearch.UniformCostSearch(graph["Arad"], graph["Bucareste"]);
            if (path != null)
            {
                Console.WriteLine(path);
            }
            else
            {
                Console.WriteLine("Path not found :(");
            }

            Console.WriteLine("\nAStar:");
            path = GraphSearch.AStarSearch(graph["Arad"], graph["Bucareste"]);
            if (path != null)
            {
                Console.WriteLine(path);
            }
            else
            {
                Console.WriteLine("Path not found :(");
            }            

            Console.ReadKey();
        }
        
    }
}
