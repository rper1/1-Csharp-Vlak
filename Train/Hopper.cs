using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
	class Hopper : IConnectable
	{
		private double loadingCapacity;
		public double LoadingCapacity { get => loadingCapacity; set => loadingCapacity = value; }
		public Hopper(double loadingCapacity)
		{
			LoadingCapacity = loadingCapacity;
		}
		public void ConnectWagon(Train train)
		{
			train.Wagons.Add(this);
		}
		public void DisconnectWagon(Train train)
		{
			if (train.Wagons.Contains(this))
			{
				train.Wagons.Remove(this);
				Console.WriteLine(" Vagon odpojen.");
			}
			else
			{
				Train.Chyba();
				Console.WriteLine(" Tento vagon nelze odpojit, vlak jej neobsahuje.");
			}
		}
		public override string ToString()
		{
			return $" Nákladní vagon, nosnost {LoadingCapacity} tun";
		}

	}
}
