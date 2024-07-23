/**************************************************************
MIT License

Copyright (c) 2024 thelolcat

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
***************************************************************/

using System;

namespace helloWorld
{
    class Program
    {
        // declaring public variables
        public static string command;
        public static string text;
        public static char textBreakUp;
        public static int counter = 1;
        public static int key = 1;
        public static int textConvert;
        public static int result;
        public static int i;        
        static void Main(string[] args)
        {            
            Console.WriteLine("CokeCoder v2.7");

            while (counter == 1) // carries on looping until you do not input
            {
                Console.WriteLine("Enter a command or type '/help' for a list of commands");
                command = Console.ReadLine() + " /end";

                // the help command lists out every command useful
                if (command.StartsWith("/help"))
                {
                    Help();
                }

                // the guide command gives info on particulars of the program
                else if (command.StartsWith("/guide"))
                {
                    Guide();
                }
                // the key command sets a key
                else if (command.StartsWith("/key"))
                {
                    Key();
                }
                
                //the encode command encodes text with given key
                else if (command.StartsWith("/encode"))
                {
                    Encode();
                }
                
                //the decode command decodes text with given key
                else if (command.StartsWith("/decode"))
                {
                    Decode();
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
                num = num - 95;
            }
            while (num < 32)
            {
                num = num + 95;
            }
            return num;
        }
        public static void Help()
        {
            Console.WriteLine("/encode <string> -> Encodes text with a key");
            Console.WriteLine("/decode <string> -> Decodes text encoded with given key");
            Console.WriteLine("/key [int] -> Sets the encoding key to given number");
            Console.WriteLine("/guide -> Prints information on the program and troubleshooting tips");
        }
        public static void Guide()
        {
            Console.WriteLine("Program info:");
            Console.WriteLine("   CokeCoder version 2.7 | Symmetric encoder");
            Console.WriteLine("   Console application, written in C# (181 lines)");
            Console.WriteLine("   Script written by _thelolcat with assistance and support from aless_dev06 and" +
                " furetto126");
            Console.WriteLine("   Last updated 11/10/2023");
            Console.WriteLine("  ");
            Console.WriteLine("If the program is not decoding properly, check if the key is accurate using /key" +
                " current");
            Console.WriteLine("If you see '?' in your encoded message, chances are that the console does not " +
                "support the coversion of that particular character. Try setting your key to a lower one for " +
                "better results");
            Console.WriteLine("Make sure there are no inaccuracies while entering commands");
            Console.WriteLine("Refer the internet for unknown programming terms");
            Console.WriteLine("Press Enter to exit the program. Alternatively type '/end'");
        }
        public static void Key()
        {
            text = Prepare(command);
                    
            if (int.TryParse(command, out result)) // checks if input is an integer
            {
                        
                    key = result;
                    Console.WriteLine($"Set key to {key}");
                        
            }
            else
            {
                if (command.Contains("current")) // shows current key
                {
                    Console.WriteLine($"The current key being used is {key}");
                }
                else
                {
                    Console.WriteLine("Error, expected an integer. Are there any indeliberate " +
                        "mistakes in your input?");
                }
            }
        }
        public static void Encode()
        {
            text = Prepare(command);
            for (i = 0; i < text.Length; i++)
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
        public static void Decode()
        {
            text = Prepare(command);
            for (i = 0; i < text.Length; i++)
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
        public static string Prepare(string command)
        {
            command = command.Replace("/decode", " ");
            command = command.Replace("/encode"," ");
            command = command.Replace("/key"," ");
            command = command.Replace("/end", " ");
            command = command.Trim();
            return command;
        }
    }
}
