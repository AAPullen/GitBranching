// File IO Serialization + Deserialization
// Our Goal: Create a text file that we can write to.
//           We also want to read the text file back into our app
//           We want to create our own class: InventoryItem
//           We will create lists of InventoryItems
//           We will save those objects to a text file, and then read them back from the text file.

// Below, we consider the possibility of running on windows or mac.

using Day18File_IO_Deserialization;
using System.Runtime.InteropServices;

//Detect the Operating system
string windowsPath = @"c:\Users\andre\temp\Inventory.txt";
string macPath = @"c:/Users/<your user name>/Desktop/Inventory.txt";
string path = string.Empty;

if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    path = windowsPath;
}

if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
{
    path = macPath;
}





// Create an inventory item instance
InventoryItem inventoryItem = new InventoryItem("001", "Cat", "Firendly cat. Please buy.", 150.00m);
string textForFile = $"{inventoryItem.ProductId}||{inventoryItem.ProductName}||{inventoryItem.Description}||{inventoryItem.Price}";

Console.WriteLine("Create a new inventory item.");

Console.Write("ID: ");
string userId = Console.ReadLine();

Console.Write("Product Name: ");
string userName = Console.ReadLine();

Console.Write("Description: ");
string userDescription = Console.ReadLine();

Console.Write("Price: ");
decimal userPrice = decimal.Parse(Console.ReadLine());

InventoryItem userInventoryItem = new InventoryItem(userId, userName, userDescription, userPrice);
// todo: create a ToString method - see InventoryItem.cs





if (!File.Exists(path))
{
    // Create a file to write to.
    using (StreamWriter sw = File.CreateText(path))
    {
        sw.WriteLine(inventoryItem);
        sw.WriteLine(userInventoryItem);
    }
}

// Open the file to read from.

Console.WriteLine("Print out the exact content of the text file:");
using (StreamReader sr = File.OpenText(path))
{
    string s;
    while ((s = sr.ReadLine()) != null)
    {
        Console.WriteLine(s);
    }
}


// How do we turn the text file back OBJECTS in our program?
// We want to turn a string into an object.
// This is known as DESERIALIZATION.
List<InventoryItem> inventoryItems = new List<InventoryItem>();

using (StreamReader sr = File.OpenText(path))
{
    string s;
    while ((s = sr.ReadLine()) != null)
    {
        string[] values = s.Split("||");

        // decimal priceFromFile = decimal.Parse(values[3]);  <-- alternate way to parse our price value to a decimal

        InventoryItem itemFromFile = new InventoryItem(values[0], values[1], values[2], decimal.Parse(values[3]));
        inventoryItems.Add(itemFromFile);
    }
}

// Loop through the deserialized objects

foreach (var item in inventoryItems)
{
    Console.WriteLine($"{item.ProductName} is {item.Price}");
}