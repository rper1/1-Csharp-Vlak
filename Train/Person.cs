using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
	class Person
	{
		private string firstName;
		private string lastName;
		public string FirstName { get => firstName; private set => firstName = value; }
		public string LastName { get => lastName; private set => lastName = value; }
		/// <summary>
		/// vytvoří instanci osoby
		/// </summary>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		public Person(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
		/// <summary>
		/// vrátí jméno osoby
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"{FirstName} {LastName}";
		}
	}
}
