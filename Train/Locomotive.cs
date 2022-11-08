using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
	class Locomotive
	{
		private Person driver;
		private Engine engine;

		internal Person Driver { get => driver; private set => driver = value; }
		internal Engine Engine { get => engine; private set => engine = value; }

		public Locomotive() { }
		public Locomotive(Person driver, Engine engine)
		{
			this.driver = driver;
			this.engine = engine;
		}
		public override string ToString()
		{
			return $"Lokomotiva, řidič: {Driver}, {Engine}";
		}
	}
}
