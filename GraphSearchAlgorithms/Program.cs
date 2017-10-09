﻿using System;
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
        static bool IsInTheBorder(Node node, List<Path> border) {
            foreach (Path path in border) {
                if (path.Equals(node)) return true;
            }
            return false;
        }
        static string PathToString(List<Node> path) {
            string msg = "";
            foreach (Node node in path) {
                msg += "-->" + node.Name;
            }
            return msg;
        }
        static void Main(string[] args)
        {
            bool found;
            InitGraph();
            Path initialState = new Path(graph["Zerind"], 0);
            Node goalState = graph["Vaslui"];

            //defining initial and final states
            List<Path> border = new List<Path>();
            List<Node> explored = new List<Node>();

            //adding initial state to the border
            border.Add(initialState);
            found = false;
            Path currentNode = null; //current node being explored
            while (!found) {
                if (border.Count == 0) {
                    //if there are no nodes in the border, we haven't found
                    break;
                }
                currentNode = border[0];
                border.RemoveAt(0);
                explored.Add(currentNode.Node);
                foreach(Neighbor neighbor in currentNode.Node.Neighbors){
                    if (!IsInTheBorder(neighbor.Node, border) && !explored.Contains(neighbor.Node)) {
                        //Console.WriteLine(currentNode.Node.Name +" -> "+neighbor.Node.Name);
                        Path newPath;
                        if (neighbor.Node.Equals(goalState)) {                             
                            newPath = new Path(neighbor.Node, currentNode.Cost+neighbor.Cost);
                            newPath.PathToMe = currentNode.PathToMe;
                            newPath.PathToMe.Add(currentNode.Node);
                            currentNode = newPath;
                            found = true;
                            break;
                        }
                        newPath = new Path(neighbor.Node, currentNode.Cost + neighbor.Cost);
                        newPath.PathToMe = currentNode.PathToMe.ToList();
                        newPath.PathToMe.Add(currentNode.Node);
                        border.Add(newPath);                        
                    }
                }
            }
            if (found)
            {
                Console.WriteLine(currentNode.Node.Name + " " + currentNode.Cost);
                Console.WriteLine(PathToString(currentNode.PathToMe));
            }
            else
            {
                Console.WriteLine("Path not found");
            }

            Console.ReadKey();
        }
    }
}
