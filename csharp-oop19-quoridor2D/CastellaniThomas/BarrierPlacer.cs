using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using csharp_oop19_quoridor2D.Fabri_Luca.Graph;
using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;
using Barrier = csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers.Barrier;

namespace csharp_oop19_quoridor2D.CastellaniThomas
{
    public class BarrierPlacer : IBarrierPlacer
    {
        //I assume that "Player1" is the player that makes the move but i need some of player2 things to do the stall check
        readonly IRoundBarriers Barriers;
        readonly Coordinate Player1Position;
        readonly Coordinate Player2Position;
        readonly int Player1FinishLine;
        readonly int Player2FinishLine;
        int Player1Barriers;

        public BarrierPlacer()
        {
            Barriers = new RoundBarriers();
            Player1Position = new Coordinate(3, 4);
            Player2Position = new Coordinate(6, 4);
            Player1FinishLine = RoundBarriers.BoardDimension;
            Player2FinishLine = 0;
            Player1Barriers = 10;
        }

        public void PlaceBarrier(Coordinate position, BarrierOrientation orientation)
        {
            if (this.CheckPlacement(position, orientation))
            {
                this.Player1Barriers--;
                if (orientation.Equals(BarrierOrientation.Horizontal))
                {
                    this.Barriers.Add(new Barrier(position, orientation, BarrierPiece.Head));
                    this.Barriers.Add(new Barrier(new Coordinate(position.First + 1, position.Second), orientation, BarrierPiece.Tail));
                }
                else
                {
                    this.Barriers.Add(new Barrier(position, orientation, BarrierPiece.Head));
                    this.Barriers.Add(new Barrier(new Coordinate(position.First, position.Second + 1), orientation, BarrierPiece.Tail));
                }
            }
            else
            {
                Console.WriteLine("Bad move! Still your turn!");
            }
        }

        private bool CheckPlacement(Coordinate position, BarrierOrientation orientation)
        {
            return this.isEmptyPosition(position, orientation) && this.EnoughBarriers() && this.CheckEdge(position) && this.NoStall(position, orientation) ? true : false;
        }

        private bool isEmptyPosition(Coordinate position, BarrierOrientation orientation)
        {
            if (this.Barriers.Contains(new Barrier(position, BarrierOrientation.Horizontal, BarrierPiece.Head)))
            {
                return false;
            }
            if (this.Barriers.Contains(new Barrier(position, BarrierOrientation.Vertical, BarrierPiece.Head)))
            {
                Console.WriteLine("Not empty!!");
                return false;
            }
            if (this.Barriers.Contains(new Barrier(position, BarrierOrientation.Horizontal, BarrierPiece.Tail)))
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
            if (this.Barriers.Contains(new Barrier(position, BarrierOrientation.Vertical, BarrierPiece.Tail)))
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
            if (this.Barriers.Contains(new Barrier(new Coordinate(position.First + 1, position.Second), BarrierOrientation.Horizontal, BarrierPiece.Head)))
            {
                if (orientation.Equals(BarrierOrientation.Horizontal))
                {
                    Console.WriteLine("Not empty!!");
                    return false;
                }
            }
            if (this.Barriers.Contains(new Barrier(new Coordinate(position.First, position.Second + 1), BarrierOrientation.Vertical, BarrierPiece.Head)))
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
            return this.Player1Barriers > 0 ? true : false;
        }

        private bool CheckEdge(Coordinate position)
        {
            //8 = Board dimension
            if (position.First == RoundBarriers.BoardDimension)
            {
                Console.WriteLine("Can't place on the edge!!");
                return false;
            }
            if (position.Second == RoundBarriers.BoardDimension)
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
                if (this.Barriers.GetBarriersAsGraph().ContainsPath(BarriersGraph.BarriersAsEdgesToRemove(playerBarrier), this.Player1Position, this.Player1FinishLine))
                {
                    if (this.Barriers.GetBarriersAsGraph().ContainsPath(BarriersGraph.BarriersAsEdgesToRemove(playerBarrier), this.Player2Position, this.Player2FinishLine))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                var playerBarrier = new List<IBarrier> { barrierPosition, barrierV };
                if (this.Barriers.GetBarriersAsGraph().ContainsPath(BarriersGraph.BarriersAsEdgesToRemove(playerBarrier), this.Player1Position, this.Player1FinishLine))
                {
                    if (this.Barriers.GetBarriersAsGraph().ContainsPath(BarriersGraph.BarriersAsEdgesToRemove(playerBarrier), this.Player2Position, this.Player2FinishLine))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}