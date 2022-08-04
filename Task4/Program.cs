using Task4;

CircularSinglyLinkedList<int> list = new CircularSinglyLinkedList<int>();
list.Add(4);
list.Add(2);
list.Add(1);
list.Add(3);
list.Add(4);
list.Add(17);
list.Add(6);
list.Add(0);

//CircularSinglyLinkedList<string> list = new CircularSinglyLinkedList<string>();
//list.Add("Ферузет");
//list.Add("Гришаня");
//list.Add("Абрам");
//list.Add("Саша");
//list.Add("Маслор");
//list.Add("Епивлорд");

Console.WriteLine("До сортировки");
foreach (var item in list)
{
	Console.WriteLine(item);
}

list.Sort();
Console.WriteLine("\nПосле сортировки");
foreach (var item in list)
{
	Console.WriteLine(item);
}