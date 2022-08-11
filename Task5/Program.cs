using Task5;

Console.WriteLine("Для получения доступа к счёту введите логин и пароль!");
Console.Write("Логин: ");
string? login = Console.ReadLine();
Console.Write("Пароль: ");
string? password = Console.ReadLine();

User? currentUser = Db.users.Find(x => x.Login == login && x.Password == password);
if (currentUser != null)
{
	Console.WriteLine($"Здравствуйте: {currentUser.FirstName} {currentUser.LastName}");
}
