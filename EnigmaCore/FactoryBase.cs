namespace nl.gn.EnigmaCore
{
    using System;
    using System.Linq;

    public class FactoryBase
    {
        protected static int[] ConvertMapping(string mapping)
        {
            if (mapping == null)
                throw new ArgumentNullException(nameof(mapping));

            int[] result = mapping
                .Select(ch => Convert.ToInt32(char.ToUpper(ch) - 'A'))
                .ToArray();

            return result;
        }
    }
}
