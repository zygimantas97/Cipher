using Cipher;
using System;
using System.Collections.Generic;

namespace CipherClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> commands = new Dictionary<string, string>()
            {
                { "e", "Encrypt" },
                { "d", "Decrypt" },
                { "h", "Help" },
                { "q", "Quick" }
            };

            Console.WriteLine("CaesarChipher");
            foreach(string k in commands.Keys)
            {
                Console.WriteLine("{0:1} - {1}", k, commands[k]);
            }

            string command = "";
            while(command != "q")
            {
                Console.WriteLine();
                Console.Write("{0, -20}", "Enter command: ");
                command = Console.ReadLine();

                switch (command)
                {
                    case "e":
                    case "d":
                        Console.Write("{0, -20}", "Enter message: ");
                        string message = Console.ReadLine();

                        int key = 0;
                        bool parsed = false;
                        while (!parsed)
                        {
                            Console.Write("{0, -20}", "Enter key: ");
                            string keyString = Console.ReadLine();
                            parsed = int.TryParse(keyString, out key);
                            if (!parsed)
                            {
                                Console.WriteLine("Wrong key format: it must be a number.");
                            }
                        }

                        string newMessage = "";
                        ICipher cipher = new CaesarCipher(key);
                        if (command == "e")
                        {
                            Console.Write("{0, -20}", "Encrypted message:");
                            newMessage = cipher.Encrypt(message);
                        }
                        else
                        {
                            Console.Write("{0, -20}", "Decrypted message:");
                            newMessage = cipher.Decrypt(message);
                        }

                        Console.WriteLine(newMessage);
                        break;
                    case "h":
                        foreach (string k in commands.Keys)
                        {
                            Console.WriteLine("{0:1} - {1}", k, commands[k]);
                        }
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Not recognized command.");
                        break;
                }
            }
        }
    }
}
