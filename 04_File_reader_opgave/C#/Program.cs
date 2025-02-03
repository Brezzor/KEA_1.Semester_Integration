// See https://aka.ms/new-console-template for more information
using System.Text.Json;

using (FileStream fileStream = File.OpenRead(@"C:\Users\olive\source\repos\KEA_1_Semester\KEA_1_Semester\04_File_reader_opgave\Text_files\me.json"))
{
    Me? me = await JsonSerializer.DeserializeAsync<Me>(fileStream);

    if (me != null)
    {
        Console.WriteLine($"Name: {me.Name}");
        Console.WriteLine($"Age: {me.Age}");
        Console.WriteLine($"Hobbies: {string.Join(", ", me.Hoppies)}");
    }
}
