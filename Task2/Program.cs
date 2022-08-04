using Task2;

CircularSinglyLinkedList<string> list = new CircularSinglyLinkedList<string>();
list.Add("Первый");
list.Add("Второй");
list.Add("Третий");
list.Add("Четветрый");

list.Insert("Пятый", 2);

//list.RemoveAt(2);
//list.RemoveAt(0);

//Console.WriteLine(list.Count);
////list.Clear();
//list.Add("First");
//Console.WriteLine(list.Count);
//Console.WriteLine($"Есть ли Первый: {list.Contains("Первый")}");
//Console.WriteLine($"Есть ли First: {list.Contains("First")}");

//Console.WriteLine(list[3]);
//list[3] = "One";

Console.ReadLine();