using System.Collections;
using System.Collections.Generic;
using System.Linq;
using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;

namespace csharp_oop19_quoridor2D.Fabri_Luca.Graph
{
    public class Graph : IGraph<Coordinate>
    {
        private IList<Pair<Coordinate, Coordinate>> edges;

        public Graph(IList<Pair<Coordinate, Coordinate>> edges)
        {
            this.edges = edges;
        }

        public Graph(int boardDimension)
        {
            IList<Coordinate> coordinates = new List<Coordinate>();
            for (int i = 0; i < boardDimension; i++)
            {
                for (int k = 0; k < boardDimension; k++)
                {
                    coordinates.Add(new Coordinate(k, i));
                }
            }
            EdgesFromCoordinates(coordinates);
        }
        private void EdgesFromCoordinates(IList<Coordinate> coordinates) {
            foreach (Coordinate c in coordinates) {
                int x = c.First;
                int y = c.Second;
                foreach (Coordinate adj in new List<Coordinate>()
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
        
        public void Remove(Pair<Coordinate, Coordinate> edge)
        {
            this.edges.Remove(edge);
            this.edges.Remove(new Pair<Coordinate, Coordinate>(edge.Second, edge.First));
        }

        public IList<Pair<Coordinate, Coordinate>> GetEdges()
        {
            return this.edges;
        }

        public IList<Pair<Coordinate, Coordinate>> BarriersAsCoordinatesToRemove(IList<IBarrier> barriers)
        {
            IList<Pair<Coordinate, Coordinate>> edgesToRemove = new List<Pair<Coordinate, Coordinate>>();

            foreach(Barrier b in barriers)
            {
                int x = b.Coordinate.First;
                int y = b.Coordinate.Second;

                if (b.Orientation.Equals(BarrierOrientation.Horizontal)) {
                    edgesToRemove.Add(new Pair<Coordinate, Coordinate>(new Coordinate(x, y), new Coordinate(x, y + 1)));
                    edgesToRemove.Add(new Pair<Coordinate, Coordinate>(new Coordinate(x, y + 1), new Coordinate(x, y)));
                } else {
                    edgesToRemove.Add(new Pair<Coordinate, Coordinate>(new Coordinate(x, y), new Coordinate(x + 1, y)));
                    edgesToRemove.Add(new Pair<Coordinate, Coordinate>(new Coordinate(x + 1, y), new Coordinate(x, y)));
                }
            }

            return edgesToRemove;
        }

        private static IList<Pair<INode, INode>> EdgesOfNodes(IList<Pair<Coordinate, Coordinate>> edges)
        {
            return edges.Select(e => new Pair<INode, INode>(new Node(e.First, Colour.White),
                    new Node(e.Second, Colour.White)))
                .ToList();
        }
        
        private IList<Node> AdjNodes(IList<Pair<Node, Node>> edgesOfNodes, Node node)
        {
            return edgesOfNodes.Where(p => p.First.GetCoordinate().Equals(node.GetCoordinate()) &&
                                           p.Second.GetColour().Equals(Colour.White))
                .Select(p => p.Second)
                .ToList();
        }

        public bool ContainsPath(IList<Pair<Coordinate, Coordinate>> coordinatesToRemove, Coordinate source, int destination)
        {
            throw new System.NotImplementedException();
        }
    }
}