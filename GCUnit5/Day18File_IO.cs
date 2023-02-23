// File IO
// Our Goal: Create a text file that we can write to.
//           We also want to read the text file back into our app


// Below, we consider the possibility of running on windows or mac.

using System.Runtime.InteropServices;

string windowsPath = @"c:\Users\andre\temp\MyTest.txt";
string macPath = @"c:/Users/<your user name>/Desktop.text";
string path = string.Empty;

//Detect the Operating system


if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    path = windowsPath;
}

if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
{
    path = macPath;
}



if (!File.Exists(path))
{
    // Create a file to write to.
    using (StreamWriter sw = File.CreateText(path))
    {
        sw.WriteLine("Hello");
        sw.WriteLine("And");
        sw.WriteLine("Welcome");
    }
}

// Open the file to read from.
using (StreamReader sr = File.OpenText(path))
{
    string s;
    while ((s = sr.ReadLine()) != null)
    {
        Console.WriteLine(s);
    }
}