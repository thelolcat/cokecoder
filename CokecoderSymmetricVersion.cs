using System;

namespace helloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // WARNING!!! The below code has not been tested yet. There may be errors in it.
            
            Console.WriteLine("CokeCoder v2.0");
            
            // declaring variables
            string command;
            string text;
            char textBreakUp;
            int counter = 1;
            int key = 1;
            int textConvert;
            int result;

            while (counter == 1) // carries on looping until you do not input
            {
                Console.WriteLine("Enter a command or type '/help' for a list of commands");
                command = Console.ReadLine() + " /end";

                // the help command lists out every command useful
                if (command.StartsWith("/help"))
                {
                    Console.WriteLine("/encode <string> -> Encodes text with a key");
                    Console.WriteLine("/decode <string> -> Decodes text encoded with given key");
                    Console.WriteLine("/key [int] -> Sets the encoding key to given number");
                    Console.WriteLine("/guide -> Prints information on the program and troubleshooting tips");
                }

                // the guide command gives info on particulars of the program
                else if (command.StartsWith("/guide"))
                {
                    Console.WriteLine("Program info:");
                    Console.WriteLine("   CokeCoder version 2.0 | Symmetric encoder");
                    Console.WriteLine("   Console application, written in C# (153 lines)");
                    Console.WriteLine("   Script written by _thelolcat with assistance and support from aless_dev06 and" +
                        " furetto126");
                    Console.WriteLine("   Last updated 27/07/2023");
                    Console.WriteLine("  ");
                    Console.WriteLine("If the program is not decoding properly, check if the key is accurate using /key" +
                        " current");
                    Console.WriteLine("If you see '?' in your encoded message, chances are that the console does not " +
                        "support the coversion of that particular character. Try setting your key to a lower one for " +
                        "better results");
                    Console.WriteLine("Make sure there are no inaccuracies while entering commands");
                    Console.WriteLine("Refer the internet for unknown program terms");
                    Console.WriteLine("Press Enter to exit the program. Alternatively type '/end'");
                }
                
                // the key command sets a key
                else if (command.StartsWith("/key"))
                {
                    command = command.Replace("/key", " ");
                    command = command.Replace("/end", " ");
                    command = command.Trim();
                    /* The above code will be seen in the upcoming two lines too. This line deletes the command and the
                     * ending string from the user input so that only the program can utilise the unique input */
                    
                    if (int.TryParse(command, out result)) // checks if input is an integer
                    {
                        if (result > 0 && result < 8) // checks if input < 8 and > 1
                        {
                            key = result;
                            Console.WriteLine($"Set key to {key}");
                        }
                        else
                        {
                            Console.WriteLine("Error, expected an integer between 1 and 7. Are there any " +
                                "indeliberate mistakes in you input?");
                        }
                    }
                    else
                    {
                        if (command.Contains("current")) // shows current key
                        {
                            Console.WriteLine($"The current key being used is {key}");
                        }
                        else
                        {
                            Console.WriteLine("Error, expected an integer between 1 and 7. Are there any indeliberate " +
                                "mistakes in your input?");
                        }
                    }
                }
                
                // the encode command encodes text with given key
                else if (command.StartsWith("/encode"))
                {
                    command = command.Replace("/encode", " ");
                    command = command.Replace("/end", " ");
                    command = command.Trim();
                    text = command;
                    for (int i = 0; i < text.Length; i++)
                    {
                        textBreakUp = text[i];
                        textConvert = (int)textBreakUp;
                        textConvert = textConvert + (key * ((i + 1) % 2 +1));
                        textConvert = Round(textConvert);
                        Console.Write((char)textConvert);
                    }
                    if (i == 0)
                    {
                        Console.WriteLine("Error, expected string input in command -> /encode <string>");
                    }
                    else
                    {
                        Console.WriteLine($" encoded using key {key}");
                    }
                }
                
                // the decode command decodes text with given key
                else if (command.StartsWith("/decode"))
                {
                    command = command.Replace("/decode", " ");
                    command = command.Replace("/end", " ");
                    command = command.Trim();
                    text = command;
                    for (int i = 0; i < text.Length; i++)
                    {
                        textBreakUp = text[i];
                        textConvert = (int)textBreakUp;
                        textConvert = textConvert - (key * ((i + 1) % 2 + 1));
                        textConvert = Round(textConvert);
                        Console.Write((char)textConvert);
                    }
                    if (i == 0)
                    {
                        Console.WriteLine("Error, expected string input in command -> /decode <string>");
                    }
                    else
                    {
                        Console.WriteLine($" decoded from {text} using key {key}");
                    }
                }
                else
                {
                    command = command.Trim();
                    if (command.StartsWith("/end")) // terminates the program
                    {
                        counter = 0;
                    }
                    else
                    {
                        Console.WriteLine("Error, unknown command. Are there any indeliberate mistakes in your input?");
                    }
                }
            }
        }
        public static int Round(int num)
        {
            while (num > 126)
            {
                num = num - 94;
            }
            while (num < 33)
            {
                num = num + 94;
            }
            return num;
        }
    }
}
