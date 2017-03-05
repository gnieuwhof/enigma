namespace nl.gn.EnigmaCore
{
    public class ReflectorFactory : FactoryBase
    {
        // https://en.wikipedia.org/wiki/Enigma_rotor_details
        // https://www.quora.com/What-was-the-wiring-of-the-Enigma

        private static readonly string REFLECTOR_A = "EJMZALYXVBWFCRQUONTSPIKHGD";
        private static readonly string REFLECTOR_B = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
        private static readonly string REFLECTOR_C = "FVPJIAOYEDRZXWGCTKUQSBNMHL";

        private static readonly string REFLECTOR_B_THIN = "ENKQAUYWJICOPBLMDXZVFTHRGS";
        private static readonly string REFLECTOR_C_THIN = "RDOBJNTKVEHMLFCWZAXGYIPSUQ";


        public static Reflector CreateReflectorA()
        {
            int[] mapping = FactoryBase.ConvertMapping(REFLECTOR_A);

            var result = new Reflector(mapping);

            return result;
        }

        public static Reflector CreateReflectorB()
        {
            int[] mapping = FactoryBase.ConvertMapping(REFLECTOR_B);

            var result = new Reflector(mapping);

            return result;
        }

        public static Reflector CreateReflectorC()
        {
            int[] mapping = FactoryBase.ConvertMapping(REFLECTOR_C);

            var result = new Reflector(mapping);

            return result;
        }

        public static ThinReflector CreateThinReflectorB()
        {
            int[] mapping = FactoryBase.ConvertMapping(REFLECTOR_B_THIN);

            var result = new ThinReflector(mapping);

            return result;
        }

        public static ThinReflector CreateThinReflectorC()
        {
            int[] mapping = FactoryBase.ConvertMapping(REFLECTOR_C_THIN);

            var result = new ThinReflector(mapping);

            return result;
        }
    }
}
