using System.Linq;
using Task5;

Console.Write("1 - Вывод информации о заданном аккаунте по логину и паролю\n" +
	"2 - Вывод данных о всех счетах заданного пользователя\n" +
	"3 - Вывод данных о всех счетах заданного пользователя, включая историю по каждому счёту\n" +
	"4 - Вывод данных о всех операциях пополенения счёта с указанием владельца каждого счёта\n" +
	"5 - Вывод данных о всех пользователях у которых на счёте сумма больше N (N задаётся из вне и может быть любой\n" +
	"Выберите действие: ");

string choice = Console.ReadLine();

switch (choice)
{
	case "1":
		PrintUserInfo();
		break;
	case "2":
		PrintUserAccountsInfo();
		break;
	case "3":
		PrintUserAccountsInfoWithHistory();
		break;
	case "4":
		PrintAllRefilOperationsWithAccountUser();
		break;
	case "5":
		Console.Write("Минимальная сумма на счёте: ");
		int sum = Int32.Parse(Console.ReadLine());
		PrintUsersWithAccountSumMoreThanN(sum);
		break;
	default:
		break;
}

void PrintUserInfo()
{
	Console.Write("Логин: ");
	string login = Console.ReadLine();
	Console.Write("Пароль: ");
	string password = Console.ReadLine();
	// ===== LINQ Запрос =====
	var user = Db.users.Where(u => u.Login == login && u.Password == password).First();
	// =======================
	if (user != null)
	{
		Console.WriteLine($"\nId: {user.Id}\n" +
		$"Имя: {user.FirstName}\n" +
		$"Фамилия: {user.LastName}\n" +
		$"Отчество: {user.MiddleName}\n" +
		$"Телефон: {user.Phone}\n" +
		$"Данные паспорта: {user.PassportData}\n" +
		$"Дата регистрации: {user.RegistrationDate}\n" +
		$"Логин: {user.Login}\n" +
		$"Пароль: {user.Password}\n");
	}
	else
	{
		Console.WriteLine("Нет аккаунта с таким логином или паролем");
	}
}

void PrintUserAccountsInfo()
{
	Console.Write("Логин: ");
	string login = Console.ReadLine();
	Console.Write("Пароль: ");
	string password = Console.ReadLine();

	// ===== LINQ Запрос =====
	var userAccounts = Db.users.Where(u => u.Login == login && u.Password == password)
		.Join(Db.accounts,
			u => u.Id,
			a => a.UserId,
			(u, a) => a);
	// =======================


	var user = Db.users.Where(u => u.Login == login && u.Password == password).First();

	Console.WriteLine($"\nПользователь: {user.FirstName} {user.MiddleName} {user.LastName}");

	foreach (var account in userAccounts)
	{
		Console.WriteLine($"\nId счёта: {account.Id}\n" +
			$"Id пользователя: {account.UserId}\n" +
			$"Дата открытия счёта: {account.OpeningDate}\n" +
			$"Сумма на счёте: {account.Sum}");
	}
}

void PrintUserAccountsInfoWithHistory()
{
	Console.Write("Логин: ");
	string? login = Console.ReadLine();

// ===== LINQ Запрос =====
	var user = Db.users.FirstOrDefault(u => u.Login == login);
	var result = Db.accounts.Where(a => a.UserId == user.Id)
		.GroupJoin(Db.history,
			a => a.Id,
			h => h.AccountId,
			(a, h) => new {
				account = a,
				history = h
			});
// =======================


	foreach (var el in result)
	{
		Console.WriteLine($"\nId счёта: {el.account.Id}\n" +
			$"Id пользователя: {el.account.UserId}\n" +
			$"Дата открытия счёта: {el.account.OpeningDate}\n" +
			$"Сумма на счёте: {el.account.Sum}\n");

		foreach (var history in el.history)
		{
			Console.WriteLine($"\tId {history.Id}\n" +
				$"\tДата операции: {history.OperationDate}\n" +
				$"\tТип операции: {history.OperationType}\n" +
				$"\tСумма: {history.Sum}\n" +
				$"\tId счёта: {history.AccountId}\n");
		}
	}
}

void PrintAllRefilOperationsWithAccountUser()
{
//===== LINQ Запрос =====
	var res = Db.history.Where(h => h.OperationType == OperationTypes.Refill)
		.Join(Db.accounts,
			h => h.AccountId,
			a => a.Id,
			(h, a) => new { h, a.UserId }
		).Join(Db.users,
			h => h.UserId,
			u => u.Id,
			(h, u) => new { history = h.h, user = u }
		);
//=======================


	foreach (var item in res)
	{
		string user = $"{item.user.LastName} {item.user.FirstName} {item.user.MiddleName}";
		Console.WriteLine($"Id: {item.history.Id}\nДата операции: {item.history.OperationDate}\nТип операции: {item.history.OperationType}\n" +
			$"Сумма: {item.history.Sum}\nId счёта: {item.history.AccountId}\n\tПользователь: {user}\n");
	}
}

void PrintUsersWithAccountSumMoreThanN(int sum)
{
	var usersWithSumMoreThanN = Db.users
		.Join(Db.accounts.Where(a => a.Sum > sum),
			u => u.Id,
			a => a.UserId,
			(u, a) => u
		).Distinct().ToList();

	Console.WriteLine($"\nПользователи у которых на счетёте сумма больше {sum}\n");

	foreach (var user in usersWithSumMoreThanN)
	{
		Console.WriteLine($"{user.LastName} {user.FirstName} {user.MiddleName}");
	}
};
