using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		/// <summary>
		/// vytvoří instanci vlaku
		/// </summary>
		/// <param name="locomotive"></param>
		public Train(Locomotive locomotive)
		{
			Locomotive = locomotive;
			Wagons = new List<IConnectable>();
		}
		/// <summary>
		/// vytvoří instanci vlaku
		/// </summary>
		/// <param name="locomotive"></param>
		/// <param name="wagons"></param>
		public Train(Locomotive locomotive, List<IConnectable> wagons)
		{
			Locomotive = locomotive;
			Wagons = wagons;
		}
		/// <summary>
		/// připojí k vlaku vagon zadaný vagon
		/// </summary>
		/// <param name="wagon"></param>
		public void ConnectWagon(IConnectable wagon)
		{
			if (locomotive.Engine.TypMotoru == TypMotoru.parni && wagons.Count >= 5)
			{
				Chyba();
				Console.WriteLine(" K parní lokomotivě lze připojit max. 5 vagonů.");
			}
			else
			{
				Wagons.Add(wagon);
			}
		}
		/// <summary>
		/// odpojí od vlaku zadaný vagon, pokud jej vlak obsahuje
		/// </summary>
		/// <param name="wagon"></param>
		public void DisconnectWagon(IConnectable wagon)
		{
			if (Wagons.Contains(wagon))
			{
				Wagons.Remove(wagon);
				Console.WriteLine(" Vagon odpojen.");
			}
			else
			{
				Train.Chyba();
				Console.WriteLine(" Tento vagon nelze odpojit, vlak jej neobsahuje.");
			}
		}
		/// <summary>
		/// vypíše všechna rezervovaná sedadla ve vlaku
		/// </summary>
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
		/// <summary>
		/// zarezervuje v zadaném vagonu konkrétní sedadlo, pokud je volné,
		/// vagon tolik sedadel obsahuje a zároveň vagon není nákladní
		/// </summary>
		/// <param name="vagon"></param>
		/// <param name="sedadlo"></param>
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
		/// <summary>
		/// vypíše červený nápis CHYBA
		/// </summary>
		public static void Chyba()
		{
			ConsoleColor puvodniBarva = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("  CHYBA => ");
			Console.ForegroundColor = puvodniBarva;
		}
		/// <summary>
		/// vrátí kompletní popis vlaku
		/// </summary>
		/// <returns></returns>
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
