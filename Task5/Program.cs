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
		PrintAccountInfo();
		break;
	case "2":

		break;
	case "3":

		break;
	case "4":

		break;
	case "5":

		break;
	default:
		break;
}

void PrintAccountInfo()
{
	Console.Write("Логин: ");
	string login = Console.ReadLine();
	Console.Write("Пароль: ");
	string password = Console.ReadLine();

	var user = Db.users.Where(u => u.Login == login && u.Password == password);
}