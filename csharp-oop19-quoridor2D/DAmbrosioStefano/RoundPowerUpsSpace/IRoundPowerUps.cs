using csharp_oop19_quoridor2D.D_Ambrosio_Stefano.PowerUpSpace;
using System.Collections.Generic;

namespace csharp_oop19_quoridor2D.D_Ambrosio_Stefano.RoundPowerUpsSpace
{
    public interface IRoundPowerUps
    {
        List<PowerUp> GetPowerUpsAsList();
        void Remove(PowerUp p);
    }
}
