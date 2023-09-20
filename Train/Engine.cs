using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
	public enum TypMotoru { diesel, elektricka, parni };
	class Engine
	{
		public TypMotoru TypMotoru { get; private set; }

		public Engine() { }
		/// <summary>
		/// vytvoří instanci motoru
		/// </summary>
		/// <param name="typMotoru"></param>
		public Engine(TypMotoru typMotoru)
		{
			TypMotoru = typMotoru;
		}
		/// <summary>
		/// vrátí typ motoru
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "Motor: " + TypMotoru;
		}
	}
}
