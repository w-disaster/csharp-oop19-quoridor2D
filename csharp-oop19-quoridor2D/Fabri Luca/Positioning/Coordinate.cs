namespace csharp_oop19_quoridor2D.Fabri_Luca.Positioning
{
    /// <summary>
    /// This class models the concept of a coordinate: a pair of two integers, respectively x axis and y axis position.
    /// </summary>
    public class Coordinate : Pair<int, int>
    {
        public Coordinate(int x, int y) : base(x, y)
        {
        }
        
    }
}