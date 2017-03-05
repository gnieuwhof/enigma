namespace nl.gn.EnigmaCore
{
    using System;
    using System.Linq;

    public class Wiring
    {
        protected readonly int[] mapping;


        public Wiring(int[] mapping)
        {
            if (mapping == null)
                throw new ArgumentNullException(nameof(mapping));
            if (mapping.Length != 26)
                throw new ArgumentException("Mapping length must be 26", nameof(mapping));
            if (mapping.Min() != 0)
                throw new ArgumentException("The lowest value in the mapping must be zero", nameof(mapping));
            if (mapping.Max() != 25)
                throw new ArgumentException("The highest value in mapping must be 25", nameof(mapping));
            if (mapping.Length != mapping.Distinct().Count())
                throw new ArgumentException("Mapping cannot contain duplicates", nameof(mapping));

            this.mapping = mapping;
        }


        public virtual int RightInput(int val)
        {
            if (val < 0)
                new ArgumentException("Value cannot be lower than zero", nameof(val));
            if (val > 25)
                throw new ArgumentException("Value cannot be higher than 25", nameof(val));

            int index = val;

            int result = this.mapping[index];

            return result;
        }
    }
}
