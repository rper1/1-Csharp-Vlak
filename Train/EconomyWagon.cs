using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
	class EconomyWagon : PersonalWagon
	{
		/// <summary>
		/// vytvoří instanci personal vagonu
		/// </summary>
		/// <param name="numberOfChairs"></param>
		public EconomyWagon(int numberOfChairs) : base(numberOfChairs)
		{
		}
		/// <summary>
		/// vrátí popis economy vagonu
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $" Economy vagon, počet sedadel: {NumberOfChairs}";
		}
	}
}
