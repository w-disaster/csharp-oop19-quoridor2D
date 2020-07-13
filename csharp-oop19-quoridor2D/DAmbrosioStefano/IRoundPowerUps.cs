using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop19_quoridor2D.DAmbrosioStefano
{
    /// <summary>
    /// The Interface that describes a list of PowerUps for a game round.
    /// </summary>
    public interface IRoundPowerUps
    {
        /// <summary>
        /// Gets the PowerUp list.
        /// </summary>
        /// <returns>
        /// The PowerUp list.
        /// </returns>
        List<PowerUp> GetPowerUpsAsList();
        /// <summary>
        /// Removes a PowerUp from the list.
        /// </summary>
        /// <param name="p"></param>
        void Remove(PowerUp p);
    }
}
