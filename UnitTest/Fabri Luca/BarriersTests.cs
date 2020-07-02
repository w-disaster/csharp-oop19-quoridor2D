using System.Collections.Generic;
using System.Linq;
using csharp_oop19_quoridor2D.Fabri_Luca.Graph;
using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class BarriersTests
    {
        private readonly IRoundBarriers rb = new RoundBarriers();
        [Test]
        public void RoundBarriersTest()
        {
            IBarrier b1 = new Barrier(new Coordinate(0, RoundBarriers.BoardDimension / 2),
                BarrierOrientation.Horizontal, BarrierPiece.Head);
            IBarrier b2 = new Barrier(new Coordinate(1, RoundBarriers.BoardDimension / 2),
                BarrierOrientation.Horizontal, BarrierPiece.Tail);
            IList<IBarrier> barriers = new List<IBarrier>()
            {
                b1, b2
            };
            foreach (var barrier in barriers)
            {
                this.rb.Add(barrier);
            }
            Assert.True(this.rb.Contains(b1));
            Assert.True(this.rb.GetBarriersAsList().Count.Equals(2));

            /*Once we placed the barriers, its corresponding edges are removed, then the list GetEdges() shouldn't 
            contain those.*/
            Assert.False(this.rb.GetBarriersAsGraph()
                .GetEdges()
                .Any(e => BarriersGraph.BarriersAsEdgesToRemove(barriers).Contains(e)));
            
        }

        [Test]
        public void BarriersGraphTest()
        {
            IList<IBarrier> barriers = new List<IBarrier>();
            /*I add horizontals barriers from column 0 to BoardDimension - 2 at line BoardDimension/2.
            NB: it doesn't matter if it is a Head one or a Tail one. */
            for(int i = 0; i < RoundBarriers.BoardDimension - 1; i++){
                barriers.Add(new Barrier(new Coordinate(i, RoundBarriers.BoardDimension / 2), 
                    BarrierOrientation.Horizontal, BarrierPiece.Head));
            }
            
            //Player 1.
            Coordinate player1 = new Coordinate(0, 0);
            int finishLine1 = RoundBarriers.BoardDimension - 1;
            
            /*For player1 there's a path to the destination.
             NB: we aren't positioning the barriers, but we make sure that for a possible placing there is a 
             a way to the finish line. */
            Assert.True(this.rb.GetBarriersAsGraph()
                .ContainsPath(BarriersGraph.BarriersAsEdgesToRemove(barriers), player1, finishLine1));
            //I add at the final column the last horizontal barrier.
            barriers.Add(new Barrier(new Coordinate(RoundBarriers.BoardDimension - 1, 
                    RoundBarriers.BoardDimension / 2), BarrierOrientation.Horizontal, BarrierPiece.Head));
            //Now there shouldn't be a path for player1.
            Assert.False(this.rb.GetBarriersAsGraph()
                .ContainsPath(BarriersGraph.BarriersAsEdgesToRemove(barriers), player1, finishLine1));
            
            //Player 2.
            Coordinate player2 = new Coordinate(RoundBarriers.BoardDimension / 2 - 1, 
                RoundBarriers.BoardDimension / 2 - 1);
            int finishLine2 = 0;
            /*There's a path for player2 because it starts above the horizontal barriers and its destination is at the
             top of the board.*/
            Assert.True(this.rb.GetBarriersAsGraph()
                .ContainsPath(BarriersGraph.BarriersAsEdgesToRemove(barriers), player2, finishLine2));
            
        }
    }
}