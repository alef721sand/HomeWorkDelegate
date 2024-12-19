
using HomeWorkDelegate;

// Walking through directory
var search_dir = @"c:\doc";

var dir_reader = new ReadDirectory();
dir_reader.FileFound += (sender, e) =>
{
    Console.WriteLine($"File found: {e.FileName}");
    // cancel the search if a file with a specific name is found
    if (e.FileName.EndsWith("stop.txt"))
    {
        Console.WriteLine("Stopping search...");
        (sender as ReadDirectory)?.CancelSearch();
    }
};

Console.WriteLine("Walking through directory...");
dir_reader.ReadDir(search_dir);

// search for the maximum collection item
var items = new List<string> {"Single Responsibility",
                              "Open/Closed",
                              "Liskov Substitution",
                              "Interface Segregation",
                              "Dependency Inversion"};
var maxItem = items.GetMax(item => item.GroupBy(c => c).Max(g => g.Count())); // Get item with maximum number of identical characters
Console.WriteLine($"Max item: {maxItem}");
