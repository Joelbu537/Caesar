using System;
class Program
{
    static void Main(string[] args)
    {
        const string ALPHABET = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";
        Console.Title = ALPHABET;
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
            if((level < 26) && (level > -26))
            {
                Console.Clear();
                string output = "";
                for(int i = 0; i < input.Length; i++)
                {
                    int id = 0;
                    for(int j = 0; j < 26; j++)
                    {
                        if (input[i] == ALPHABET[j])
                        {
                            id = j;
                            break;
                        }
                    }
                    output += ALPHABET[26 + id + level];
                }
                if(level < 0)
                {
                    Console.WriteLine($"Input:  {input.ToLower()}");
                    Console.WriteLine($"Output: {output.ToUpper()}");
                }
                if(level > 0)
                {
                    Console.WriteLine($"Input:  {input.ToUpper()}");
                    Console.WriteLine($"Output: {output.ToLower()}");
                }
                if(level == 0)
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