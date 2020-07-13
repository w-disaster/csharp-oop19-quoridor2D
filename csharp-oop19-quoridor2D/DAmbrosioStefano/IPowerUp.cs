using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
