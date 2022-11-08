using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
	class Train
	{
		private Locomotive locomotive;
		private List<IConnectable> wagons;
		internal Locomotive Locomotive { get => locomotive; set => locomotive = value; }
		internal List<IConnectable> Wagons { get => wagons; set => wagons = value; }
		public Train() { }
		public Train(Locomotive locomotive)
		{
			Locomotive = locomotive;
			Wagons = new List<IConnectable>();
		}
		public Train(Locomotive locomotive, List<IConnectable> wagons)
		{
			Locomotive = locomotive;
			Wagons = wagons;
		}
		public void ConnectWagon(IConnectable wagon)
		{
			if (wagons.Count < 5)
			{
				wagon.ConnectWagon(this);
			}
			else
			{
				Chyba();
				Console.WriteLine(" K parní lokomotivě lze připojit max. 5 vagonů.");
			}
		}
		public void DisconnectWagon(IConnectable wagon)
		{
			wagon.DisconnectWagon(this);
		}

		public void ListReservedChairs()
		{
			string s = " Rezervovaná sedadla:\n";
			for (int i = 0; i < wagons.Count; i++)
			{
				if (wagons[i].GetType().BaseType.Name == "PersonalWagon")
				{
					s += $" Vagon {i + 1}: ";
					for (int j = 0; j < ((PersonalWagon)wagons[i]).NumberOfChairs; j++)
					{
						if (((PersonalWagon)wagons[i]).Sits[j].Reserved == true)
						{
							s += $"sedadlo č.{j + 1}  ";
						}
					}
					s += "\n";
				}
				else
				{
					s += $" Vagon {i + 1}: Nákladní\n";
				}
			}
			Console.WriteLine(s);
		}
		public void ReserveChair(int vagon, int sedadlo)
		{
			if (wagons[vagon - 1].GetType().BaseType.Name == "PersonalWagon")
			{
				PersonalWagon pev = (PersonalWagon)wagons[vagon - 1];
				if (sedadlo <= pev.NumberOfChairs)
				{
					if (pev.Sits[sedadlo - 1].Reserved == false)
					{
						pev.Sits[sedadlo - 1].Reserved = true;
					}
					else
					{
						Chyba();
						Console.WriteLine($" Sedadlo {sedadlo} ve vagonu {vagon} v tomto vlaku už je rezervováno.");
					}
				}
				else
				{
					Chyba();
					Console.WriteLine(" Tolik sedadel v tomto vagonu není.");
				}

			}
			else
			{
				Chyba();
				Console.WriteLine(" V tomto vagonu nelze rezervovat sedadlo, protože vagon je nákladní.");
			}
		}

		public static void Chyba()
		{
			ConsoleColor puvodniBarva = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("  CHYBA => ");
			Console.ForegroundColor = puvodniBarva;
		}

		public override string ToString()
		{
			string ret = " VLAK:\n";
			ret += $" {Locomotive}\n";
			for (int i = 0; i < wagons.Count; i++)
			{
				ret += $" Vagon č.{i + 1}: {wagons[i]}";
				ret += "\n";
			}
			return ret;
		}
	}
}
