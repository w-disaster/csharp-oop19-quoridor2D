using System.Collections.Generic;
using System.Linq;
using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;

namespace csharp_oop19_quoridor2D.Fabri_Luca.Graph
{    
    /// <summary>
    /// Bidirectional graph that models barriers as holes of edges.
    /// </summary>
    public class BarriersGraph : IGraph<Coordinate>
    {
        private IList<Pair<Coordinate, Coordinate>> edges;

        public BarriersGraph(IList<Pair<Coordinate, Coordinate>> edges)
        {
            this.edges = edges;
        }

        public BarriersGraph(int boardDimension)
        {
            this.edges = new List<Pair<Coordinate, Coordinate>>();
            IList<Coordinate> coordinates = new List<Coordinate>();
            for (var i = 0; i < boardDimension; i++)
            {
                for (var k = 0; k < boardDimension; k++)
                {
                    coordinates.Add(new Coordinate(k, i));
                }
            }
            EdgesFromCoordinates(coordinates);
        }
        
        /// <summary>
        /// Converts barriers to edges to remove
        /// </summary>
        /// <param name="barriers"></param>
        /// <returns>the list of the edges to remove</returns>
        public static IList<Pair<Coordinate, Coordinate>> BarriersAsEdgesToRemove(IList<IBarrier> barriers)
        {
            IList<Pair<Coordinate, Coordinate>> edgesToRemove = new List<Pair<Coordinate, Coordinate>>();

            foreach(var b in barriers)
            {
                var x = b.Coordinate.First;
                var y = b.Coordinate.Second;

                if (b.Orientation.Equals(BarrierOrientation.Horizontal)) {
                    edgesToRemove.Add(new Pair<Coordinate, Coordinate>(new Coordinate(x, y), 
                        new Coordinate(x, y + 1)));
                    edgesToRemove.Add(new Pair<Coordinate, Coordinate>(new Coordinate(x, y + 1), 
                        new Coordinate(x, y)));
                } else {
                    edgesToRemove.Add(new Pair<Coordinate, Coordinate>(new Coordinate(x, y), 
                        new Coordinate(x + 1, y)));
                    edgesToRemove.Add(new Pair<Coordinate, Coordinate>(new Coordinate(x + 1, y), 
                        new Coordinate(x, y)));
                }
            }
            
            return edgesToRemove;
        }
        
        public void Remove(Pair<Coordinate, Coordinate> edge)
        {
            this.edges.Remove(edge);
            this.edges.Remove(new Pair<Coordinate, Coordinate>(edge.Second, edge.First));
        }

        public IList<Pair<Coordinate, Coordinate>> GetEdges()
        {
            return this.edges;
        }
        
        public bool ContainsPath(IList<Pair<Coordinate, Coordinate>> edgesToRemove, Coordinate source, int destination)
        {
            IList<INode> list = new List<INode>();

            IList<Pair<INode, INode>> edgesOfNodes = EdgesOfNodes(this.edges
                .Where(e => !edgesToRemove.Contains(e))
                .ToList());
            
            INode s = new Node(source, Colour.Gray);
            list.Add(s);
            
            //Computing algorithm: Breadth First Search (BFS)
            while (list.Count > 0)
            {
                INode u = list[0];
                list.RemoveAt(0);
                foreach (var v in AdjNodes(edgesOfNodes, u))
                {
                    if (v.Coordinate.Second.Equals(destination))
                    {
                        return true;
                    }
                    v.Colour = Colour.Gray;
                    list.Add(v);
                }
                u.Colour = Colour.Black;
            }

            return false;
        }
        
        /// <summary>
        /// Private method to build the graph given the nodes, that in this case are the board coordinates.
        /// </summary>
        /// <param name="coordinates"></param>
        private void EdgesFromCoordinates(IList<Coordinate> coordinates) {
            foreach (var c in coordinates) {
                var x = c.First;
                var y = c.Second;
                foreach (var adj in new List<Coordinate>()
                {
                    new Coordinate(x - 1, y),
                    new Coordinate(x + 1, y),
                    new Coordinate(x , y - 1),
                    new Coordinate(x, y + 1),

                })
                {
                    this.edges.Add(new Pair<Coordinate, Coordinate>(c, adj));
                }
            }
        }
        
        /// <summary>
        /// Edges of two nodes
        /// </summary>
        /// <param name="edges"></param>
        /// <returns>edges of nodes from edges of coordinates</returns>
        private static IList<Pair<INode, INode>> EdgesOfNodes(IList<Pair<Coordinate, Coordinate>> edges)
        {
            return edges.Select(e => new Pair<INode, INode>(new Node(e.First, Colour.White),
                    new Node(e.Second, Colour.White)))
                .ToList();
        }
        
        /// <summary>
        /// Adjacent nodes
        /// </summary>
        /// <param name="edgesOfNodes"></param>
        /// <param name="node"></param>
        /// <returns>adjacent nodes of node</returns>
        private static IList<INode> AdjNodes(IList<Pair<INode, INode>> edgesOfNodes, INode node)
        {
            return edgesOfNodes.Where(p => p.First.Coordinate.Equals(node.Coordinate) &&
                                           p.Second.Colour.Equals(Colour.White))
                .Select(p => p.Second)
                .ToList();
        }
        
    }
}