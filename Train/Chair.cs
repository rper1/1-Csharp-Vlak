using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
	class Chair
	{
		private bool nearWindow;
		private int number;
		private bool reserved;

		public bool NearWindow { get => nearWindow; private set => nearWindow = value; }
		public int Number { get => number; private set => number = value; }
		public bool Reserved { get => reserved; set => reserved = value; }
		/// vytvoří instanci sedadla
		public Chair() { }
		/// <summary>
		/// vytvoří instanci sedadla
		/// </summary>
		/// <param name="nearWindow"></param>
		/// <param name="number"></param>
		/// <param name="reserved"></param>
		public Chair(bool nearWindow, int number, bool reserved)
		{
			NearWindow = nearWindow;
			Number = number;
			Reserved = reserved;
		}
	}
}
