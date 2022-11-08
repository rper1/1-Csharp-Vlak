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
		public PersonalWagon(int numberOfChairs)
		{
			NumberOfChairs = numberOfChairs;
			Sits = new List<Chair>();
			for (int i = 0; i < numberOfChairs; i++)
			{
				sits.Add(new Chair());
			}
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
	}
}
