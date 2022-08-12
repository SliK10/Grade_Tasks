namespace Task5
{
	internal class Account
	{
		private static int nextId = 0;
		public int Id { get; init; } = ++nextId;
		public DateTime OpeningDate { get; init; } = DateTime.Now;
		public int Sum { get; set; }
		public int UserId { get; init; }

		public Account(int userId, int sum)
		{
			UserId = userId;
			Sum = sum;
		}
	}
}
