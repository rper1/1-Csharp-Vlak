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

		public Engine(TypMotoru typMotoru)
		{
			TypMotoru = typMotoru;
		}

		public override string ToString()
		{
			return "Motor: " + TypMotoru;
		}
	}
}
