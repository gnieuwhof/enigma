namespace EnigmaConsole
{
    using nl.gn.EnigmaCore;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var reflector = ReflectorFactory.CreateReflectorB();
            var thinReflector = ReflectorFactory.CreateThinReflectorB();
            
            ThinRotor thinRotor = RotorFactory.CreateRotorBeta();

            Rotor slowRotor = RotorFactory.CreateRotorI();
            Rotor middleRotor = RotorFactory.CreateRotorII();
            Rotor fastRotor = RotorFactory.CreateRotorIII();

            var spindle = new Spindle(reflector, slowRotor, middleRotor, fastRotor);
            //var spindle = new Spindle(thinReflector, thinRotor, slowRotor, middleRotor, fastRotor);

            // Ringstellung.
            thinRotor.Offset = ToI('A');
            slowRotor.Offset = ToI('A');
            middleRotor.Offset = ToI('A');
            fastRotor.Offset = ToI('A');

            const char thinRotorPosition = 'A';
            const char slowRotorPosition = 'A';
            const char middleRotorPosition = 'A';
            const char fastRotorPosition = 'A';

            // Initial positions.
            thinRotor.Position = ToI(thinRotorPosition);
            slowRotor.Position = ToI(slowRotorPosition);
            middleRotor.Position = ToI(middleRotorPosition);
            fastRotor.Position = ToI(fastRotorPosition);

            // Note: Enigma can only encrypt/decrypt the 26 letters of the alphabet.
            // (because of this all others: spaces, quotes, commas etc. are ignored)
            string plain = "The quick brown fox jumps over the lazy dog.";

            var plugs = new Dictionary<int, int>
            {
                //{ ToI('A'), ToI('B') },
                //{ ToI('C'), ToI('D') },
                //{ ToI('E'), ToI('F') },
                //{ ToI('G'), ToI('H') },
                //{ ToI('I'), ToI('J') },
                //{ ToI('K'), ToI('L') },
                //{ ToI('M'), ToI('N') },
                //{ ToI('O'), ToI('P') },
                //{ ToI('Q'), ToI('R') },
                //{ ToI('S'), ToI('T') },
                //{ ToI('U'), ToI('V') },
                //{ ToI('W'), ToI('X') },
                //{ ToI('Y'), ToI('Z') },
            };

            var plugboard = new Plugboard(spindle, plugs);

            string encrypted = String.Empty;

            Console.WriteLine("Encrypted:");

            // Encrypt.
            foreach (char c in plain)
            {
                int input = ToI(c);

                if ((input < 0) || (input > 25))
                {
                    // We cannot process this char.
                    continue;
                }

                var output = plugboard.Get(input);

                var ch = Convert.ToChar('A' + output);
                encrypted += ch;
                Console.Write(ch);
                Console.Write(' ');
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Decrypted:");

            // Reset rotor positions.
            thinRotor.Position = ToI(thinRotorPosition);
            slowRotor.Position = ToI(slowRotorPosition);
            middleRotor.Position = ToI(middleRotorPosition);
            fastRotor.Position = ToI(fastRotorPosition);

            // Decrypt.
            foreach (char c in encrypted)
            {
                int input = ToI(c);

                var output = plugboard.Get(input);

                var ch = Convert.ToChar('A' + output);

                Console.Write(ch);
                Console.Write(' ');
            }

            Console.ReadKey();
        }

        private static int ToI(char ch)
        {
            return (char.ToUpper(ch) - 'A');
        }
    }
}
