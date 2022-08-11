namespace Task5
{
	internal class User
	{
		private static int nextId = 0;
		public int Id { get; init; } = nextId++;
		public string FirstName { get; init; }
		public string LastName { get; init; }
		public string MiddleName { get; init; }
		public string Phone { get; init; }
		public string PassportData { get; init; }
		public DateTime RegistrationDate { get; init; }
		public string Login { get; init; }
		public string Password { get; init; }

		public User(string firstName, string lastName, string middleName, string phone, string passportData, string login, string password )
		{
			FirstName = firstName;
			LastName = lastName;
			MiddleName = middleName;
			Phone = phone;
			PassportData = passportData;
			Login = login;
			Password = password;
		}
	}
}
