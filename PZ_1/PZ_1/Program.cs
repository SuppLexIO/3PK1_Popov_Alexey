using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
namespace PZ_1
{
    class Program
    {
        static void Main(string[] args)
        {

            var graph = new Graph();
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");
            var e = new Node("E");
            graph.Nodes.Add(a);
            graph.Nodes.Add(b);
            graph.Nodes.Add(c);
            graph.Nodes.Add(d);
            graph.Nodes.Add(e);
            graph.Edges.Add(new Edge(a, b, 5));
            graph.Edges.Add(new Edge(a, c, 2));
            graph.Edges.Add(new Edge(b, c, 1));
            graph.Edges.Add(new Edge(b, d, 3));
            graph.Edges.Add(new Edge(c, d, 1));
            graph.Edges.Add(new Edge(c, e, 4));
            graph.Edges.Add(new Edge(d, e, 1));
            Dijkstra.FindShortestPaths(graph, a);
            foreach (var node in graph.Nodes)
            {
                Console.WriteLine($"Node {node.Name}: Distance = {node.Distance}");
            }
        }



        public class Graph
        {
            public List<Node> Nodes { get; set; }
            public List<Edge> Edges { get; set; }
            public Graph()
            {
                Nodes = new List<Node>();
                Edges = new List<Edge>();
            }
        }

        public class Node
        {
            public string Name { get; set; }
            public List<Edge> Edges { get; set; }
            public double Distance { get; set; }
            public Node Previous { get; set; }
            public Node(string name)
            {
                Name = name;
                Edges = new List<Edge>();
                Distance = double.PositiveInfinity;
            }
        }
        public class Edge
        {
            public Node From { get; set; }
            public Node To { get; set; }
            public double Weight { get; set; }
            public Edge(Node from, Node to, double weight)
            {
                From = from;
                To = to;
                Weight = weight;
            }
        }



        public class Dijkstra
        {
            public static void FindShortestPaths(Graph graph, Node start)
            {
                start.Distance = 0;
                var queue = new PriorityQueue<Node>();
                queue.Enqueue(start);
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    foreach (var edge in current.Edges)
                    {
                        var neighbor = edge.To;
                        var distance = current.Distance + edge.Weight;
                        if (distance < neighbor.Distance)
                        {
                            neighbor.Distance = distance;
                            neighbor.Previous = current;
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }
        }

    }
}

