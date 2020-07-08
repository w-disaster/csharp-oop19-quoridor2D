using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop19_quoridor2D.D_Ambrosio_Stefano
{
    class RoundPowerUps
    {
        public static readonly int BarrierPowerUpNumber = 3;
        public static readonly int MovePowerUpNumber = 3;

        private List<PowerUp> powerUpList;

        public RoundPowerUps()
        {
            powerUpList = new List<PowerUp>;

			for (int i = 0; i < BarrierPowerUpNumber; i++)
			{
				PowerUp p = new PowerUp(Type.PlusOneBarrier);
				if (this.powerUpList.Any() && this.powerUpList.Contains(p))
				{
					i--;
				}
				else
				{
					this.powerUpList.Add(p);
				}
			}
			for (int i = 0; i < MovePowerUpNumber; i++)
			{
				PowerUp p = new PowerUp(Type.PlusOneMove);
				if (this.powerUpList.Any() && this.powerUpList.Contains(p))
				{
					i--;
				}
				else
				{
					this.powerUpList.Add(p);
				}
			}
		}

		public RoundPowerUps(List<PowerUp> powerUpList)
		{
			this.powerUpList = powerUpList;
		}

		public List<PowerUp> getPowerUpsAsList() {
				return this.powerUpList;
			}

		public void remove(PowerUp p)
			{
				this.powerUpList.Remove(p);
			}
	}
}
