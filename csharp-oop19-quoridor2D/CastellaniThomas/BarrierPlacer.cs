using System;
using System.Collections;
using csharp_oop19_quoridor2D.Fabri_Luca;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;

namespace csharp_oop19_quoridor2D.CastellaniThomas
{
    public class BarrierPlacer : IBarrierPlacer
    {
        //I assume that "Player1" is the player that makes the move but i need some of player2 things to do the stall check
        IRoundBarriers Barriers;
        Coordinate Player1Position;
        Coordinate Player2Position;
        int Player1FinishLine;
        int Player2FinishLine;
        int Player1Barriers;

        public BarrierPlacer()
        {
            Barriers = new RoundBarriers();
            Player1Position = new Coordinate(3, 4);
            Player2Position = new Coordinate(6, 4);
            Player1FinishLine = 8;
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
                    this.Barriers.add(new Barrier(position, orientation, BarrierPiece.Head));
                    this.Barriers.add(new Barrier(new Coordinate(position.getX() + 1, position.getY()), orientation, BarrierPiece.TAIL));
                }
                else
                {
                    this.Barriers.add(new Barrier(position, orientation, BarrierPiece.HEAD));
                    this.Barriers.add(new Barrier(new Coordinate(position.getX(), position.getY() + 1), orientation, BarrierPiece.TAIL));
                }
            }
            else
            {
                Console.WriteLine("Bad move! Still your turn!");
            }
        }

        private bool CheckPlacement(Coordinate position, BarrierOrientation orientation)
        {
            return this.isEmptyPosition(position, orientation) && this.enoughBarriers() && this.checkEdge(position) && this.noStall(position, orientation) ? true : false;
        }

        private boolean isEmptyPosition(Coordinate position, BarrierOrientation orientation)
        {
            if (this.Barriers.contains(new Barrier(position, BarrierOrientation.HORIZONTAL, BarrierPiece.HEAD)))
            {
                return false;
            }
            if (this.Barriers.contains(new Barrier(position, BarrierOrientation.VERTICAL, BarrierPiece.HEAD)))
            {
                Console.WriteLine("Not empty!!");
                return false;
            }
            if (this.Barriers.contains(new Barrier(position, BarrierOrientation.HORIZONTAL, BarrierPiece.TAIL)))
            {
                if (orientation.equals(BarrierOrientation.HORIZONTAL))
                {
                    Console.WriteLine("Not empty!!");
                    return false;
                }
                else
                {
                    if (!this.checkEmptyNextPosition(position, orientation))
                    {
                        return false;
                    }
                }
            }
            if (this.Barriers.contains(new Barrier(position, BarrierOrientation.VERTICAL, BarrierPiece.TAIL)))
            {
                if (orientation.equals(BarrierOrientation.VERTICAL))
                {
                    Console.WriteLine("Not empty!!");
                    return false;
                }
                else
                {
                    if (!this.checkEmptyNextPosition(position, orientation))
                    {
                        return false;
                    }
                }
            }
            if (!this.checkEmptyNextPosition(position, orientation))
            {
                return false;
            }
            return true;
        }

        private bool checkEmptyNextPosition(Coordinate position, BarrierOrientation orientation)
        {
            if (this.Barriers.contains(new Barrier(new Coordinate(position.getX() + 1, position.getY()), BarrierOrientation.HORIZONTAL, BarrierPiece.HEAD)))
            {
                if (orientation.equals(BarrierOrientation.HORIZONTAL))
                {
                    Console.WriteLine("Not empty!!");
                    return false;
                }
            }
            if (this.Barriers.contains(new Barrier(new Coordinate(position.getX(), position.getY() + 1), BarrierOrientation.VERTICAL, BarrierPiece.HEAD)))
            {
                if (orientation.equals(BarrierOrientation.VERTICAL))
                {
                    Console.WriteLine("Not empty!!");
                    return false;
                }
            }
            return true;
        }

        private boolean enoughBarriers()
        {
            return this.Player1Barriers > 0 ? true : false;
        }

        private boolean checkEdge(Coordinate position)
        {
            //8 = Board dimension
            if (position.getX() == 8)
            {
                Console.WriteLine("Can't place on the edge!!");
                return false;
            }
            if (position.getY() == 8)
            {
                Console.WriteLine("Can't place on the edge!!");
                return false;
            }
            return true;
        }

        private boolean noStall(Coordinate position, BarrierOrientation orientation)
        {
            /*
            if (orientation.equals(BarrierOrientation.HORIZONTAL))
            {
                if (this.Barriers.getBarriersAsGraph().containsPath(this.Barriers.getBarriersAsGraph().barriersAsEdgesToRemove(IList.of(new Barrier(position, orientation, BarrierPiece.HEAD),
                        new Barrier(new Coordinate(position.getX() + 1, position.getY()), orientation, BarrierPiece.TAIL))), this.Player1Position, this.Player1FinishLine))
                {
                    if (this.Barriers.getBarriersAsGraph().containsPath(this.Barriers.getBarriersAsGraph().barriersAsEdgesToRemove(IList.of(new Barrier(position, orientation, BarrierPiece.HEAD),
                            new Barrier(new Coordinate(position.getX() + 1, position.getY()), orientation, BarrierPiece.TAIL))), this.Player2Position, this.Player2FinishLine))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                if (this.Barriers.getBarriersAsGraph().containsPath(this.Barriers.getBarriersAsGraph().barriersAsEdgesToRemove(IList.of(new Barrier(position, orientation, BarrierPiece.HEAD),
                        new Barrier(new Coordinate(position.getX(), position.getY() + 1), orientation, BarrierPiece.TAIL))), this.Player1Position, this.Player1FinishLine))
                {
                    if (this.Barriers.getBarriersAsGraph().containsPath(this.Barriers.getBarriersAsGraph().barriersAsEdgesToRemove(IList.of(new Barrier(position, orientation, BarrierPiece.HEAD),
                            new Barrier(new Coordinate(position.getX(), position.getY() + 1), orientation, BarrierPiece.TAIL))), this.Player2Position, this.Player2FinishLine))
                    {
                        return true;
                    }
                }
                return false;
            }
            */
            return true;
        }

        public void PlaceBarrier(Coordinate position, BarrierOrientation orientation)
        {
            throw new NotImplementedException();
        }
    }
}