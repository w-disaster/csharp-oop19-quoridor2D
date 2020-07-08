using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop19_quoridor2D.D_Ambrosio_Stefano
{
    public interface IRoundPowerUps
    {
        List<PowerUp> GetPowerUpsAsList();
        void Remove(PowerUp p);
    }
}
