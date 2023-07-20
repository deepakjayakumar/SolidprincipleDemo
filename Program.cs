// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SolidprincipleDemo
{

    public class Journal
    {
        public readonly List<string> entries = new List<string>();

        public static int count = 1;

        public int AddEntry(string text)
        {
            entries.Add($"{++count} : {text}");
            return (count);
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
            
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void Savefile(Journal j, string filename, bool overwrite = false)
        {
            if(overwrite && !File.Exists(filename)) 
                File.WriteAllText(filename,j.ToString());
        }
    }
    public class program
    {
        public static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("My firt Journal");
            j.AddEntry("My Second Journal");
             Console.WriteLine(j.ToString());

            var p = new Persistence();
            string filename = @"c:\Training\Dotnet\journal.txt";
            p.Savefile(j, filename, true);
            Process.Start(filename);

        }
    }
}




