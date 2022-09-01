// Парсер URL-адресов с заданной HTML страницы

//Написать программу, которая:
//	1.На вход принимает URL-адрес,
//	2. Загружает HTML-текст с этого адреса.
//	3. Находит URL-адреса, используя регулярное выражение.
//	4. Выводит на экран список всех найденных URL-адресов.

using System.Net;
using System.Text.RegularExpressions;

Console.Write("Введите URL адрес страницы: ");
string url = Console.ReadLine();
string htmlBody;

HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{url}");
//request.UseDefaultCredentials = true;
request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36";

HttpWebResponse response = (HttpWebResponse)request.GetResponse();

using (Stream stream = response.GetResponseStream())
{
	using (StreamReader reader = new StreamReader(stream))
	{
		htmlBody = reader.ReadToEnd();
	}
}

Regex regex = new Regex(@"https?://.+?(?="")", RegexOptions.Compiled | RegexOptions.IgnoreCase);
MatchCollection matches = regex.Matches(htmlBody);

if (matches.Count > 0)
{
	foreach (Match match in matches)
	{
		Console.WriteLine(match.Value);
	}
}
else
{
	Console.WriteLine("Не найдено ни одного URL адреса");
}
