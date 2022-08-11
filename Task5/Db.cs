namespace Task5
{
	internal static class Db
	{
		public static List<User> users = new List<User>
		{
			new User("Виктор", "Прохоров", "Геннадиевич", "+791234567890", "3207123321", "Vitya", "123"),
			new User("Абрам", "Гутенбергов", "Рюрикович", "+79987654321", "9010321123", "Abram", "321"),
			new User("Виталий", "Смоленсков", "Вурдалакович", "+79779997766", "7500909656", "Vitalic", "123"),
		};
		public static List<Account> accounts = new List<Account>
		{
			new Account(1, 516),
			new Account(2, 10000),
			new Account(1, 1600),
			new Account(3, 234000),
			new Account(3, 17000),
		};

		public static List<History> history = new List<History>
		{
			new History(OperationTypes.Refill, 1000, 1),
			new History(OperationTypes.Withdrawal, 7000, 2),
			new History(OperationTypes.Refill, 234000, 3),
			new History(OperationTypes.Refill, 17000, 3),
		};
	}
}
