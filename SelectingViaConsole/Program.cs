namespace SelectingViaConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elections = new string[] { "First", "Second", "Third"};
            int? nullable_index = Choose(elections);
            int index = Convert.ToInt32(nullable_index);
            Console.WriteLine();
            Console.WriteLine($"You choose {elections[index]}");

            Console.ReadLine();
        }

        static int? Choose(params string[] options)
        {
            try
            {
                int index = 0;
                string prefix = "►";
                ConsoleKeyInfo keyinfo;
                do
                {
                    Console.Clear();
                    for (int i = 0; i < options.Length; i++)
                    {
                        if (index == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine(prefix + $"{i + 1}. "
                            + options[i]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"{i + 1}. " + options[i]);
                        }
                    }
                    keyinfo = Console.ReadKey(true);
                    if (keyinfo.Key == ConsoleKey.UpArrow)
                    {
                        if (index == 0) index = options.Length - 1;
                        else index--;
                    }
                    else if (keyinfo.Key == ConsoleKey.DownArrow)
                    {
                        if (index == options.Length - 1) index = 0;
                        else index++;
                    }
                    Console.ResetColor();
                }
                while (keyinfo.Key != ConsoleKey.Enter);
                Console.Clear();
                return index;
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return null;
            }
        }

    }
}