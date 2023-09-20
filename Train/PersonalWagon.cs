using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
	abstract class PersonalWagon : IConnectable
	{
		private List<Door> doors = new List<Door>();
		private List<Chair> sits;
		private int numberOfChairs;
		public int NumberOfChairs { get => numberOfChairs; set => numberOfChairs = value; }
		internal List<Door> Doors { get => doors; set => doors = value; }
		internal List<Chair> Sits { get => sits; set => sits = value; }
		/// <summary>
		/// vytvoří instanci vagonu
		/// </summary>
		/// <param name="numberOfChairs"></param>
		public PersonalWagon(int numberOfChairs)
		{
			NumberOfChairs = numberOfChairs;
			Sits = new List<Chair>();
			for (int i = 0; i < numberOfChairs; i++)
			{
				sits.Add(new Chair());
			}
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
		/// odpojí vagon ze zadaného vlaku
		/// </summary>
		/// <param name="train"></param>
		public void DisconnectWagon(Train train)
		{
			train.DisconnectWagon(this);
		}
	}
}
