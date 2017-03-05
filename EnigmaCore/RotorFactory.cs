namespace nl.gn.EnigmaCore
{
    public class RotorFactory : FactoryBase
    {
        // https://en.wikipedia.org/wiki/Enigma_rotor_details
        // https://www.quora.com/What-was-the-wiring-of-the-Enigma

        private static readonly string ROTOR_I = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
        private static readonly string ROTOR_II = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
        private static readonly string ROTOR_III = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
        private static readonly string ROTOR_IV = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
        private static readonly string ROTOR_V = "VZBRGITYUPSDNHLXAWMJQOFECK";
        private static readonly string ROTOR_VI = "JPGVOUMFYQBENHZRDKASXLICTW";
        private static readonly string ROTOR_VII = "NZJHGRCXMYSWBOUFAIVLPEKQDT";
        private static readonly string ROTOR_VIII = "FKQHTLXOCBJSPDZRAMEWNIUYGV";

        private static readonly string ROTOR_BETA = "LEYJVCNIXWPBQMDRTAKZGFUHOS";
        private static readonly string ROTOR_GAMMA = "FSOKANUERHMBTIYCWLQPZXVGJD";


        public static Rotor CreateRotorI()
        {
            int[] mapping = FactoryBase.ConvertMapping(ROTOR_I);
            int[] notchPositions = new[] { 'Q' - 'A' };

            var result = new Rotor(mapping, notchPositions, 0);

            return result;
        }

        public static Rotor CreateRotorII()
        {
            int[] mapping = FactoryBase.ConvertMapping(ROTOR_II);
            int[] notchPositions = new[] { 'E' - 'A' };

            var result = new Rotor(mapping, notchPositions, 0);

            return result;
        }

        public static Rotor CreateRotorIII()
        {
            int[] mapping = FactoryBase.ConvertMapping(ROTOR_III);
            int[] notchPositions = new[] { 'V' - 'A' };

            var result = new Rotor(mapping, notchPositions, 0);

            return result;
        }

        public static Rotor CreateRotorIV()
        {
            int[] mapping = FactoryBase.ConvertMapping(ROTOR_IV);
            int[] notchPositions = new[] { 'J' - 'A' };

            var result = new Rotor(mapping, notchPositions, 0);

            return result;
        }

        public static Rotor CreateRotorV()
        {
            int[] mapping = FactoryBase.ConvertMapping(ROTOR_V);
            int[] notchPositions = new[] { 'Z' - 'A' };

            var result = new Rotor(mapping, notchPositions, 0);

            return result;
        }

        public static Rotor CreateRotorVI()
        {
            int[] mapping = FactoryBase.ConvertMapping(ROTOR_VI);
            int[] notchPositions = new[] { ('Z' - 'A'), ('M' - 'A') };

            var result = new Rotor(mapping, notchPositions, 0);

            return result;
        }

        public static Rotor CreateRotorVII()
        {
            int[] mapping = FactoryBase.ConvertMapping(ROTOR_VII);
            int[] notchPositions = new[] { ('Z' - 'A'), ('M' - 'A') };

            var result = new Rotor(mapping, notchPositions, 0);

            return result;
        }

        public static Rotor CreateRotorVIII()
        {
            int[] mapping = FactoryBase.ConvertMapping(ROTOR_VIII);
            int[] notchPositions = new[] { ('Z' - 'A'), ('M' - 'A') };

            var result = new Rotor(mapping, notchPositions, 0);

            return result;
        }

        public static ThinRotor CreateRotorBeta()
        {
            int[] mapping = FactoryBase.ConvertMapping(ROTOR_BETA);

            var result = new ThinRotor(mapping, 0);

            return result;
        }

        public static ThinRotor CreateRotorGamma()
        {
            int[] mapping = FactoryBase.ConvertMapping(ROTOR_GAMMA);

            var result = new ThinRotor(mapping, 0);

            return result;
        }
    }
}
