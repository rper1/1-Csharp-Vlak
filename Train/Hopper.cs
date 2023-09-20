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
		/// <summary>
		/// vytvoří instanci nákladního vagonu
		/// </summary>
		/// <param name="loadingCapacity"></param>
		public Hopper(double loadingCapacity)
		{
			LoadingCapacity = loadingCapacity;
		}
		/// <summary>
		/// připojí vagon k zadanému vlaku
		/// </summary>
		/// <param name="train"></param>
		public void ConnectWagon(Train train)
		{
			train.ConnectWagon(this);
		}
		/// <summary>
		/// odpojí vagon od zadaného vlaku, pokud jej obsahuje
		/// </summary>
		/// <param name="train"></param>
		public void DisconnectWagon(Train train)
		{
			train.DisconnectWagon(this);
		}
		/// <summary>
		/// vrátí popis vagonu
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $" Nákladní vagon, nosnost {LoadingCapacity} tun";
		}

	}
}
