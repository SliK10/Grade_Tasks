using System.Reflection;

namespace MyApp // Note: actual namespace depends on the project name.
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Team noName = new Team(new[]
			{
				new Footballer("Abraham", 10),
				new Footballer("Ben", 13),
				new Footballer("Cortny", 89),
				new Footballer("Datsun", 7),
				new Footballer("Erevan", 1),
				new Footballer("Fluent", 14),
				new Footballer("Greg", 54),
				new Footballer("Hunter", 93),
				new Footballer("Ivan", 32),
				new Footballer("Jack", 68),
				new Footballer("Oleg", 2)
			});


			noName[30] = new Footballer { name = "20", number = 20 };
			//noName[20] = new Footballer("20", 20);

			var fb = noName[30];
			Console.WriteLine(fb.name);
		}
	}

	public class Team
	{
		Footballer[] footballers;

		public Team(Footballer[] footballers)
		{
			this.footballers = footballers;
		}
		public Footballer this[int number]
		{
			get 
			{
				try
				{
					return footballers[number];
				}
				catch (Exception)
				{
					throw new Exception("В этой команде нет футболиста с таким номером");
				}
			}

			set
			{
				if (footballers.Length < number)
					Array.Resize(ref footballers, number + 1);

				footballers[number] = value;
			}
		}

		//public Footballer this[string name]
		//{
		//    get
		//    {
		//        foreach (var gamer in footballers)
		//        {
		//            if (gamer.Name == name) return gamer;
		//        }
		//        throw new Exception("В этой команде нет футболиста с таким именем");
		//    }
		//}
	}

	public class Footballer
	{
		public string name;
		public int number;

		public Footballer()
		{
			this.name = "Unknown";
			this.number = 0;
		}
		public Footballer(string name, int number)
		{
			this.name = name;
			this.number = number;
		}
	}
}
