using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using csharp_oop19_quoridor2D.FabriLuca.Graph;
using csharp_oop19_quoridor2D.FabriLuca.Positioning;
using csharp_oop19_quoridor2D.FabriLuca.RoundBarriers;
using Barrier = csharp_oop19_quoridor2D.FabriLuca.RoundBarriers.Barrier;

namespace csharp_oop19_quoridor2D.CastellaniThomas
{
    public class BarrierPlacer : IBarrierPlacer
    {
        //I assume that "Player1" is the player that makes the move but i need some of player2 things to do the stall check
        readonly IRoundBarriers barriers;
        readonly Coordinate player1Position;
        readonly Coordinate player2Position;
        readonly int player1FinishLine;
        readonly int player2FinishLine;
        int player1Barriers;

        public BarrierPlacer()
        {
            barriers = new RoundBarriers();
            player1Position = new Coordinate(3, 4);
            player2Position = new Coordinate(6, 4);
            player1FinishLine = RoundBarriers.BOARD_DIMENSION - 1;
            player2FinishLine = 0;
            player1Barriers = 10;
        }

        public void PlaceBarrier(Coordinate position, BarrierOrientation orientation)
        {
            if (this.CheckPlacement(position, orientation))
            {
                this.player1Barriers--;
                if (orientation.Equals(BarrierOrientation.Horizontal))
                {
                    this.barriers.Add(new Barrier(position, orientation, BarrierPiece.Head));
                    this.barriers.Add(new Barrier(new Coordinate(position.First + 1, position.Second), orientation, BarrierPiece.Tail));
                }
                else
                {
                    this.barriers.Add(new Barrier(position, orientation, BarrierPiece.Head));
                    this.barriers.Add(new Barrier(new Coordinate(position.First, position.Second + 1), orientation, BarrierPiece.Tail));
                }
            }
            else
            {
                Console.WriteLine("Bad move! Still your turn!");
            }
        }

        public bool CheckPlacement(Coordinate position, BarrierOrientation orientation)
        {
            return this.IsEmptyPosition(position, orientation) && this.EnoughBarriers() && this.CheckEdge(position) && this.NoStall(position, orientation) ? true : false;
        }

        private bool IsEmptyPosition(Coordinate position, BarrierOrientation orientation)
        {
            if (this.barriers.Contains(new Barrier(position, BarrierOrientation.Horizontal, BarrierPiece.Head)))
            {
                return false;
            }
            if (this.barriers.Contains(new Barrier(position, BarrierOrientation.Vertical, BarrierPiece.Head)))
            {
                Console.WriteLine("Not empty!!");
                return false;
            }
            if (this.barriers.Contains(new Barrier(position, BarrierOrientation.Horizontal, BarrierPiece.Tail)))
            {
                if (orientation.Equals(BarrierOrientation.Horizontal))
                {
                    Console.WriteLine("Not empty!!");
                    return false;
                }
                else
                {
                    if (!this.CheckEmptyNextPosition(position, orientation))
                    {
                        return false;
                    }
                }
            }
            if (this.barriers.Contains(new Barrier(position, BarrierOrientation.Vertical, BarrierPiece.Tail)))
            {
                if (orientation.Equals(BarrierOrientation.Vertical))
                {
                    Console.WriteLine("Not empty!!");
                    return false;
                }
                else
                {
                    if (!this.CheckEmptyNextPosition(position, orientation))
                    {
                        return false;
                    }
                }
            }
            if (!this.CheckEmptyNextPosition(position, orientation))
            {
                return false;
            }
            return true;
        }

        private bool CheckEmptyNextPosition(Coordinate position, BarrierOrientation orientation)
        {
            if (this.barriers.Contains(new Barrier(new Coordinate(position.First + 1, position.Second), BarrierOrientation.Horizontal, BarrierPiece.Head)))
            {
                if (orientation.Equals(BarrierOrientation.Horizontal))
                {
                    Console.WriteLine("Not empty!!");
                    return false;
                }
            }
            if (this.barriers.Contains(new Barrier(new Coordinate(position.First, position.Second + 1), BarrierOrientation.Vertical, BarrierPiece.Head)))
            {
                if (orientation.Equals(BarrierOrientation.Vertical))
                {
                    Console.WriteLine("Not empty!!");
                    return false;
                }
            }
            return true;
        }

        private bool EnoughBarriers()
        {
            return this.player1Barriers > 0 ? true : false;
        }

        private bool CheckEdge(Coordinate position)
        {
            //8 = Board dimension
            if (position.First == RoundBarriers.BOARD_DIMENSION - 1)
            {
                Console.WriteLine("Can't place on the edge!!");
                return false;
            }
            if (position.Second == RoundBarriers.BOARD_DIMENSION - 1)
            {
                Console.WriteLine("Can't place on the edge!!");
                return false;
            }
            return true;
        }

        private bool NoStall(Coordinate position, BarrierOrientation orientation)
        {
            var barrierPosition = new Barrier(position, orientation, BarrierPiece.Head);
            var barrierH = new Barrier(new Coordinate(position.First + 1, position.Second), orientation, BarrierPiece.Tail);
            var barrierV = new Barrier(new Coordinate(position.First, position.Second + 1), orientation, BarrierPiece.Tail);

            if (orientation.Equals(BarrierOrientation.Horizontal))
            {
                var playerBarrier = new List<IBarrier> { barrierPosition, barrierH };
                if (this.barriers.GetBarriersAsGraph().ContainsPath(BarriersGraph.BarriersAsEdgesToRemove(playerBarrier), this.player1Position, this.player1FinishLine))
                {
                    if (this.barriers.GetBarriersAsGraph().ContainsPath(BarriersGraph.BarriersAsEdgesToRemove(playerBarrier), this.player2Position, this.player2FinishLine))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                var playerBarrier = new List<IBarrier> { barrierPosition, barrierV };
                if (this.barriers.GetBarriersAsGraph().ContainsPath(BarriersGraph.BarriersAsEdgesToRemove(playerBarrier), this.player1Position, this.player1FinishLine))
                {
                    if (this.barriers.GetBarriersAsGraph().ContainsPath(BarriersGraph.BarriersAsEdgesToRemove(playerBarrier), this.player2Position, this.player2FinishLine))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}