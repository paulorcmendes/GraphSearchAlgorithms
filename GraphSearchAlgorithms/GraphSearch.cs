using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearchAlgorithms
{
    class GraphSearch
    {
        public static Path BreadthFirstSearch(Node initial, Node goal)
        {
            bool found;
            Path initialState = new Path(initial, 0);
            Node goalState = goal;
            if (initial.Equals(goal))
            {
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
                        //foreach (Path p in border) {
                        //    Console.Write(p.Node+" c:"+p.Cost+" e:"+p.Node.Expectation+"s: "+(p.Cost+p.Node.Expectation)+"; ");                            
                        //}
                        //Console.WriteLine();
                        //Console.ReadKey();
                    }
                }
            }
            if (found) return currentNode;
            return null;
        }

        public static Path UniformCostSearch(Node initial, Node goal)
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
                        //foreach (Path p in border)
                        //{
                        //    Console.Write(p.Node + " c:" + p.Cost + " e:" + p.Node.Expectation + "s: " + (p.Cost + p.Node.Expectation) + "; ");
                        //}
                        //Console.WriteLine();
                        //Console.ReadKey();
                    }
                }
            }
            if (found) return currentNode;
            return null;
        }

        public static Path AStarSearch(Node initial, Node goal)
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
                        //foreach (Path p in border)
                        //{
                        //    Console.Write(p.Node + " c:" + p.Cost + " e:" + p.Node.Expectation + "s: " + (p.Cost + p.Node.Expectation) + "; ");
                        //}
                        //Console.WriteLine();
                        //Console.ReadKey();
                    }
                }
            }
            if (found) return currentNode;
            return null;
        }

        private static bool IsInTheBorder(Node node, List<Path> border)
        {
            foreach (Path path in border)
            {
                if (path.Node.Equals(node)) return true;
            }
            return false;
        }
    }
}
