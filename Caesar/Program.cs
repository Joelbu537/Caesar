using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        string ALPHABET = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";
        string space_type = "";
        Console.Title = "Caesar";
        string config_path = Path.Combine(Directory.GetCurrentDirectory(), "config.cfg");
        int alphabet_length = 26;
        if (Path.Exists(config_path))
        {
            try
            {
                string[] config = File.ReadAllLines(config_path);
                int config_zero = Convert.ToInt32(config[0]);
                if (config[1] == "1")
                {
                    ALPHABET = "abcdefghijklmnopqrstuvwxyzäöüßabcdefghijklmnopqrstuvwxyzäöüßabcdefghijklmnopqrstuvwxyzäöüß";
                    alphabet_length = 30;
                }
                switch(config_zero)
                {
                    case 0:
                        space_type = " ";
                        break;
                    case 1:
                        space_type = "";
                        break;
                    case 2:
                        space_type = "-";
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                Console.WriteLine("Try to delete config.cfg from the application folder");
                Console.ReadKey();
            }
        }
        else
        {
            string[] preferences = new string[2];
            Console.WriteLine("Please select your preferences");
            Console.WriteLine("WARNING: Missinputs can only be corrected");
            Console.WriteLine("by deleting config.cfg from the application folder!");
            Console.WriteLine();
            Console.WriteLine("Blanks should be [0]LEFT AS THEY ARE [1]REMOVED [2]REPLACED WITH -");
            preferences[0] = Convert.ToString(Console.ReadKey().KeyChar);
            Console.WriteLine("The alphabet should contain special characters such as ü, ß and more");
            Console.WriteLine("[0]DO NOT INCLUDE [1]INCLUDE");
            preferences[1] = Convert.ToString(Console.ReadKey().KeyChar);
            Console.Clear();
            File.WriteAllLines(config_path, preferences);
        }
        while(true)
        {
            Console.Clear();
            Console.Write("String: ");
            string input = Console.ReadLine().ToLower();
            Console.Write("Encryption level (Use negative numbers to decode): ");
            int level = 100;
            try
            {
                level = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            if((level < alphabet_length) && (level > -alphabet_length))
            {
                Console.Clear();
                string output = "";
                for(int i = 0; i < input.Length; i++)
                {
                    int id = 0;
                    for(int j = 0; j < alphabet_length; j++)
                    {
                        if (input[i] == ALPHABET[j])
                        {
                            id = j;
                            break;
                        }
                    }
                    if (input[i] == ' ')
                    {
                        output += space_type;
                    }
                    else
                    {
                        output += ALPHABET[alphabet_length + id + level];
                    }
                }
                if(level <= 0)
                {
                    Console.WriteLine($"Input:  {input.ToLower()}");
                    Console.WriteLine($"Output: {output.ToUpper()}");
                }
                if(level > 0)
                {
                    Console.WriteLine($"Input:  {input.ToUpper()}");
                    Console.WriteLine($"Output: {output.ToLower()}");
                }
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid encryption level!");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}