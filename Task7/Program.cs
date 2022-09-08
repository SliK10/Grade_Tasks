using System.Reflection;

Person person = new Person
{
	FirstName = "Антон",
	MiddleName = "Семёнович",
	LastName = "Шпак"
};

PrintPersonClassInfo(person);

Type type = typeof(Person);
type.GetField("salary", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(person, 80000);

person.PrintPhrase();




static void PrintPersonClassInfo(Person person)
{
	Type type = person.GetType();

	var properties = type.GetProperties();

	Console.WriteLine("Свойства");
	foreach (var property in properties)
	{
		Console.WriteLine($"{property.PropertyType} {property.Name}");
	}

	var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

	Console.WriteLine("\nПоля");
	foreach (var field in fields)
	{
		string modificator = "public";

		if (field.IsPrivate)
			modificator = "private";

		Console.WriteLine($"{modificator} {field.Name} : {field.GetValue(person)}");
	}

	var methods = type.GetMethods();

	Console.WriteLine("\nМетоды");
	foreach (var method in methods)
	{
		Console.WriteLine($"{method.Name} {method.ReturnType}");
	}

	type.GetMethod("PrintPhrase")?.Invoke(person, parameters: null);

	// Можно с помощью MemberInfo проделать то же самое.
	//foreach (MemberInfo member in type.GetMembers())
	//{
	//	Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
	//}

}

public class Person
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string MiddleName { get; set; }

	int salary = 100000;

	public void PrintPhrase()
	{
		Console.WriteLine($"\nЯ {LastName} {FirstName} {MiddleName} зарабатываю {salary} рублей.");
	}
}
