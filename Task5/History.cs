namespace Task5
{
	internal class History
	{
		private static int nextId = 0;
		public int Id { get; init; } = nextId++;
		public DateTime OperationDate { get; init; } = DateTime.Now;
		public OperationTypes OperationType { get; init; }
		public int Sum { get; init; }
		public int AccountId { get; init; }

		public History(OperationTypes operationType, int sum, int accountId)
		{
			OperationType = operationType;
			Sum = sum;
			AccountId = accountId;
		}
	}
}
