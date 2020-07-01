﻿using System;
 using System.CodeDom;
 using System.Collections.Generic;
 using System.Linq;
 using csharp_oop19_quoridor2D.Fabri_Luca.Graph;
 using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
 using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;
 using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class Tests
    {
        private IRoundBarriers rb = new RoundBarriers();
        [Test]
        public void BarriersTest()
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

            Assert.False(this.rb.GetBarriersAsGraph()
                .GetEdges()
                .Any(e => BarriersGraph.BarriersAsEdgesToRemove(barriers).Contains(e)));
            
        }

        [Test]
        public void GraphTest()
        {
            IList<IBarrier> barriers = new List<IBarrier>();
            
            for(int i = 0; i < 2; i++){
                barriers.Add(new Barrier(new Coordinate(i, RoundBarriers.BoardDimension / 2), 
                    BarrierOrientation.Horizontal, BarrierPiece.Head));
            }
            
            Assert.True(this.rb.GetBarriersAsGraph()
                .ContainsPath(BarriersGraph.BarriersAsEdgesToRemove(barriers), new Coordinate(0, 0), RoundBarriers.BoardDimension - 1));
            
        }
    }
}