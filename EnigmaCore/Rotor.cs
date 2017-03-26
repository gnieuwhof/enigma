namespace nl.gn.EnigmaCore
{
    using System;
    using System.Linq;

    public class Rotor : OffsetableRotor
    {
        public Rotor(int[] mapping, int[] notchPositions, int offset)
            : base(mapping, notchPositions, offset)
        {
            if (notchPositions.Length == 0)
                throw new ArgumentException("There must be at least one notch position", nameof(notchPositions));
            if (notchPositions.Min() < 0)
                throw new ArgumentException("Value cannot be lower than zero", nameof(notchPositions));
            if (notchPositions.Min() > 25)
                throw new ArgumentException("A notch position cannot be higher than 25", nameof(notchPositions));
        }
    }
}
