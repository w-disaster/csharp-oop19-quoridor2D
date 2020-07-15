using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_oop19_quoridor2D.FabriLuca.Positioning;

namespace csharp_oop19_quoridor2D.DAmbrosioStefano
{
    /// <summary>
    /// The Interface that describes a PowerUp.
    /// </summary>
    public interface IPowerUp
    {
        Type Type
        {
            get;
        }

        Coordinate Coordinate
        {
            get;
        }
    }
}
