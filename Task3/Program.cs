using Task3;

CircularSinglyLinkedList<string> list = new CircularSinglyLinkedList<string>();
list.Add("Первый");
list.Add("Второй");
list.Add("Третий");
list.Add("Четветрый");

list.Insert("Пятый", 2);

foreach (var item in list)
{
	Console.WriteLine(item);
}

Console.ReadLine();