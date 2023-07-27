using System;

namespace helloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CokeCoder v1.1 | C# Symmetric Encoder");
            
            // declares variables (before loop)
            string function;
            string encrypt;
            int codeKey;
            int coder;
            int i = 1;
            double result;
            char code;
            int digit1;
            int digit2;
            int digit3;
            
            // determines function
            Console.WriteLine("Encode/Decode/Generate Key/Help");
            function = Console.ReadLine();
            function = function.ToLower();
            
            // generates key
            if (function.Contains("generate"))
            {
                Console.WriteLine("Enter a random number between 1000 and 9999");
                if (double.TryParse(Console.ReadLine(), out result) && result > 1000 && result < 9999)
                {
                    result = Math.Pow(result, 3); // input raised to the power of 3
                    Console.WriteLine($"New key -> {result % 100}"); // prints key (remainder on dividing result by 100)
                    Console.ReadKey();
                }
                else // responds to an invalid input
                {
                    Console.WriteLine("Invalid input: expected double between 1000 and 9999");
                    Console.ReadKey();
                }
            }
            else if (function.Contains("encode"))
            {
                Console.WriteLine("Enter key"); // input codekey
                codeKey = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter message"); // input message to be encrypted
                encrypt = Console.ReadLine();

                for (i = 0; i < encrypt.Length; i++)
                {
                    // encrypts each char by adding codekey*(i-1) to the int of the char
                    coder = (int)encrypt[i];
                    coder = coder + (codeKey * (i + 1));
                    
                    while (coder > 999) // minus 1000 if coder is above 999
                    {
                        coder = coder - 1000;
                    }
                    
                    while (coder < 100) // prints a zero before the int if int is below 100
                    {
                        Console.Write("0");
                    }
                    Console.Write(coder);
                }
                
                // prints encoded message
                Console.Write($" encrypted using codekey {codeKey}.");
                Console.WriteLine(" Restart for other commands");
                Console.ReadKey();
            }
            else if (function.Contains("decode"))
            {
                Console.WriteLine("Enter key"); // input codekey
                codeKey = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter code"); // input secret code
                encrypt = Console.ReadLine();
                while (i < encrypt.Length - 2)
                {
                    // assigns three digits to each int variable
                    code = encrypt[i];
                    digit1 = code * 100;
                    code = encrypt[i + 1];
                    digit2 = code * 10;
                    code = encrypt[i + 2];
                    digit3 = code;
                    
                    // finds out and decrypts the set of three digits
                    coder = digit1 + digit2 + digit3;
                    coder = coder - (codeKey * ((i + 1) / 3));
                    while (coder < 0)
                    {
                        coder = coder + 25;
                    }

                    // prints end result
                    Console.Write(Convert.ToChar(coder));
                    if (i > encrypt.Length - 2)
                    {
                        break;
                    }
                    else
                    {
                        i = i + 3;
                    }
                }
                Console.WriteLine("Restart for other commands");
                Console.ReadKey();
            }
            else if (function.Contains("help"))
            {
                Console.WriteLine("Enter 'encode' to encode a message into a secret code with a key");
                Console.WriteLine("Enter 'decode' to decode a secret code encrypted using this encoder");
                Console.WriteLine("Enter 'generate' to generate a key for encryption");
                Console.WriteLine("C# (90 lines), script written by _thelolcat@Discord using Visual Studio 2019");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Wrong command, restart and try again or enter 'help' for info");
                Console.ReadKey();
            }
        }
    }
}

