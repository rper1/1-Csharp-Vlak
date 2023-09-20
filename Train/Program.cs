using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ConsoleColor puvodniBarva = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("\n Každý vlak je složen z lokomotivy (ta obsahuje instance řidiče a motoru) a z vagonů.\n");
			Console.ForegroundColor = puvodniBarva;

			Console.WriteLine("\n Vytvoř EV - vagon ekonomický, 30 sedadel.");
			EconomyWagon ev1 = new EconomyWagon(30);

			Console.WriteLine(" Vytvoř BV - vagon business, 20 sedadel, stewardka Lenka Kozáková.");
			BusinessWagon bv1 = new BusinessWagon(20, new Person("Lenka", "Kozáková"));

			Console.WriteLine(" Vytvoř SV - vagon spací, 20 postelí, 10 sedadel.");
			NightWagon nv1 = new NightWagon(10, 20);

			Console.WriteLine(" Vytvoř NV1 - vagon nákladní, nosnost 21 tun.");
			Hopper hv1 = new Hopper(21);

			Console.WriteLine(" Vytvoř R1 - řidič, Karel Novák.");
			Person p1 = new Person("Karel", "Novák");

			Console.WriteLine(" Vytvoř M1 - motor, dieselový.");
			Engine e1 = new Engine(TypMotoru.diesel);

			Console.WriteLine(" Vytvoř L1 - lokomotiva, řidič R1, motor M1.");
			Locomotive lo1 = new Locomotive(p1, e1);

			// vytvoření vlaku V1
			Console.WriteLine(" Vytvoř V1 - vlak složený z: L1, EV, BV, SV, NV1.");
			Train tr1 = new Train(lo1, new List<IConnectable> { ev1, bv1, nv1, hv1 });


			Console.WriteLine(" Vytvoř NV2 - vagon nákladní, nosnost 22 tun.");
			Hopper hv2 = new Hopper(22);
			Console.WriteLine(" Připoj 2 vagony NV2 k vlaku V1.\n");
			hv2.ConnectWagon(tr1);
			hv2.ConnectWagon(tr1);

			Console.WriteLine(" Vytvoř NV3 - vagon nákladní, nosnost 23 tun.");
			Hopper hv3 = new Hopper(23);
			Console.WriteLine(" Vytvoř NV4 - vagon nákladní, nosnost 24 tun.");
			Hopper hv4 = new Hopper(24);
			Console.WriteLine(" Vytvoř NV5 - vagon nákladní, nosnost 25 tun.");
			Hopper hv5 = new Hopper(25);
			Console.WriteLine(" Vytvoř NV6 - vagon nákladní, nosnost 26 tun.");
			Hopper hv6 = new Hopper(26);
			Console.WriteLine(" Vytvoř NV7 - vagon nákladní, nosnost 27 tun.");
			Hopper hv7 = new Hopper(27);
			Console.WriteLine(" Vytvoř NV8 - vagon nákladní, nosnost 28 tun.");
			Hopper hv8 = new Hopper(28);

			// vytvoření vlaku V2
			Console.WriteLine("\n Vytvoř V2 - vlak složený z: " +
				"nová lokomotiva (nový řidič Petr Svoboda, nový parní motor), vagony NV3 NV4 NV5 NV6 NV7.");
			Train tr2 = new Train(new Locomotive(new Person("Petr", "Svoboda"),
				new Engine(TypMotoru.parni)), new List<IConnectable> { hv3, hv4, hv5, hv6, hv7 });

			Console.WriteLine("\n Připoj k vlaku V2 vagon NV8.");
			tr2.ConnectWagon(hv8);          // K parní lokomotivě lze připojit max. 5 vagonů.

			Console.WriteLine("\n Odpoj vagon NV8 od vlaku V2 (použije metodu vlaku).");
			hv8.DisconnectWagon(tr2);       // Tento vagon nelze odpojit, vlak jej neobsahuje.
			Console.WriteLine("\n Odpoj od vlaku V2 vagon NV8.");
			tr2.DisconnectWagon(hv8);       // Tento vagon nelze odpojit, vlak jej neobsahuje.
			Console.WriteLine("\n Rezervuj sedadlo 5 ve vagonu 3 vlaku 1.");
			tr1.ReserveChair(3, 5);
			Console.WriteLine("\n Rezervuj sedadlo 5 ve vagonu 3 vlaku 1.");
			tr1.ReserveChair(3, 5);         // Sedadlo 5 ve vagonu 3 už je rezervováno.
			Console.WriteLine("\n Rezervuj sedadlo 31 ve vagonu 1 vlaku 1.");
			tr1.ReserveChair(1, 31);        // Tolik sedadel v tomto vagonu není.
			Console.WriteLine("\n Rezervuj sedadlo 2 ve vagonu 2 vlaku 2.");
			tr2.ReserveChair(2, 2);         // V tomto vagonu nelze rezervovat sedadlo, protože je nákladní.

			Console.WriteLine("\n Vypiš všechna rezervovaná sedadla ve vlaku V1:\n");
			tr1.ListReservedChairs();       // Rezervovaná sedadla ve vlaku 1
			Console.WriteLine("\n Vypiš kompletní vlak V1:\n");
			Console.WriteLine(tr1);         // Vypíše kompletní vlak 1
			Console.WriteLine("\n Vypiš kompletní vlak V2:\n");
			Console.WriteLine(tr2);         // Vypíše kompletní vlak 2
			Console.ReadKey();
		}
	}
}
