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
        static bool IsInTheBorder(Node node, List<Path> border) 
        {
            foreach (Path path in border) {
                if (path.Equals(node)) return true;
            }
            return false;
        }
        
        static void Main(string[] args)
        {            
            InitGraph();
            Console.WriteLine("BFS:");
            Console.WriteLine(BreadthFirstSearch(graph["Arad"], graph["Bucareste"]));
            Console.WriteLine("Dijkstra:");
            Console.WriteLine(UniformCostSearch(graph["Arad"], graph["Bucareste"]));
            Console.WriteLine("A Star:");
            Console.WriteLine(AStarSearch(graph["Arad"], graph["Bucareste"]));

            Console.ReadKey();
        }

        static Path BreadthFirstSearch(Node initial, Node goal) 
        {
            bool found;
            Path initialState = new Path(initial, 0);
            Node goalState = goal;
            if (initial.Equals(goal)) {
                initialState.PathToMe.Add(initial);
                return initialState;
            }                  

            //defining initial and final states
            List<Path> border = new List<Path>();
            List<Node> explored = new List<Node>();

            //adding initial state to the border
            border.Add(initialState);
            found = false;
            Path currentNode = null; //current node being explored
            while (!found)
            {
                if (border.Count == 0)
                {
                    //if there are no nodes in the border, we haven't found
                    break;
                }

                //removing the node that is currently being explored from the border
                currentNode = border[0];
                border.RemoveAt(0);
                //adding node to the explored set
                explored.Add(currentNode.Node);
                foreach (Neighbor neighbor in currentNode.Node.Neighbors)
                {
                    if (!IsInTheBorder(neighbor.Node, border) && !explored.Contains(neighbor.Node))
                    {
                        //new path created using the current node reached and the cost to reach it
                        Path newPath = new Path(neighbor.Node, currentNode.Cost + neighbor.Cost);

                        //saying that the path to me is the path to my father plus my father itself
                        newPath.PathToMe = currentNode.PathToMe.ToList();
                        newPath.PathToMe.Add(currentNode.Node); ;

                        if (neighbor.Node.Equals(goalState))
                        {
                            currentNode = newPath;
                            //adding the goal node to the path
                            currentNode.PathToMe.Add(currentNode.Node);
                            found = true;
                            break;
                        }
                        border.Add(newPath);
                    }
                }
            }
            if(found) return currentNode;
            return null;
        }

        static Path UniformCostSearch(Node initial, Node goal)
        {
            bool found;
            Path initialState = new Path(initial, 0);
            Node goalState = goal;         

            //defining initial and final states
            List<Path> border = new List<Path>();
            List<Node> explored = new List<Node>();

            //adding initial state to the border
            border.Add(initialState);
            found = false;
            Path currentNode = null; //current node being explored
            while (!found)
            {
                if (border.Count == 0)
                {
                    //if there are no nodes in the border, we haven't found
                    break;
                }

                //removing the node that is currently being explored from the border
                currentNode = border[0];
                border.RemoveAt(0);

                if (currentNode.Node.Equals(goalState))
                {
                    //adding the goal node to the path
                    currentNode.PathToMe.Add(currentNode.Node);
                    found = true;
                    break;
                }

                //adding node to the explored set
                explored.Add(currentNode.Node);
                foreach (Neighbor neighbor in currentNode.Node.Neighbors)
                {
                    if (!explored.Contains(neighbor.Node))
                    {
                        //new path created using the current node reached and the cost to reach it
                        Path newPath = new Path(neighbor.Node, currentNode.Cost + neighbor.Cost);

                        //saying that the path to me is the path to my father plus my father itself
                        newPath.PathToMe = currentNode.PathToMe.ToList();
                        newPath.PathToMe.Add(currentNode.Node);


                        border.Add(newPath);
                        border.Sort();
                    }
                }
            }
            if (found) return currentNode;
            return null;
        }

        static Path AStarSearch(Node initial, Node goal)
        {
            bool found;
            Path initialState = new Path(initial, 0, CATEGORY.A_STAR);
            Node goalState = goal;         

            //defining initial and final states
            List<Path> border = new List<Path>();
            List<Node> explored = new List<Node>();

            //adding initial state to the border
            border.Add(initialState);
            found = false;
            Path currentNode = null; //current node being explored
            while (!found)
            {
                if (border.Count == 0)
                {
                    //if there are no nodes in the border, we haven't found
                    break;
                }

                //removing the node that is currently being explored from the border
                currentNode = border[0];
                border.RemoveAt(0);

                if (currentNode.Node.Equals(goalState))
                {
                    //adding the goal node to the path
                    currentNode.PathToMe.Add(currentNode.Node);
                    found = true;
                    break;
                }

                //adding node to the explored set
                explored.Add(currentNode.Node);
                foreach (Neighbor neighbor in currentNode.Node.Neighbors)
                {
                    if (!explored.Contains(neighbor.Node))
                    {
                        //new path created using the current node reached and the cost to reach it
                        Path newPath = new Path(neighbor.Node, currentNode.Cost + neighbor.Cost, CATEGORY.A_STAR);

                        //saying that the path to me is the path to my father plus my father itself
                        newPath.PathToMe = currentNode.PathToMe.ToList();
                        newPath.PathToMe.Add(currentNode.Node);


                        border.Add(newPath);
                        border.Sort();
                    }
                }
            }
            if (found) return currentNode;
            return null;
        }
    }
}
