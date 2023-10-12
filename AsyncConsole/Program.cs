// See https://aka.ms/new-console-template for more information
using AsyncConsole;
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Hello, World!");

Async sync = new Async();
var sum = sync.sum(5, 7);
Console.WriteLine(sum);

Console.WriteLine("************************************");

var sumAsync = sync.sumAsync(5, 7);
Console.WriteLine(sumAsync.Result);


// create list of tasks
List<Task> tasks = new List<Task>();
tasks.Add(sumAsync);

var filename = "C:\\Users\\adhik\\Downloads\\AsyncConsole\\AsyncConsole\\myadventure.txt";
var worktask = sync.ReadBook(filename);
tasks.Add(worktask);

Task ts = await Task.FromResult(Task.WhenAll(tasks));
if (ts.Status == TaskStatus.RanToCompletion)
{
    Console.WriteLine("All process sucessfylly completed");
}