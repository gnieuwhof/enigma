namespace nl.gn.EnigmaCore
{
    using System;
    using System.Linq;

    public class RotorBase : Wiring
    {
        /*
         * Note: there is no "ringstellung" or ring offset in this class.
         * This, because from a cryptographic point off view, the offset
         * does not add any strength.
         */

        private int position;

        /*
         * Note: Notch positions is an array because some rotors have two
         * turnover positions (rotors VI, VII & VIII).
         * Technically we could have 26 notch positions (basically killing one rotor)
         * but any number of notches above one decreases security!!
         * (So German navy, good job)
         */
        private readonly int[] notchPositions;


        public RotorBase(int[] mapping, int[] notchPositions)
            : base(mapping)
        {
            if (notchPositions == null)
                throw new ArgumentNullException(nameof(notchPositions));

            this.notchPositions = notchPositions;
        }


        public virtual int Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Value cannot be lower than zero", nameof(value));

                int temp = (value % 26);

                this.position = temp;
            }
        }

        public bool IsNotchPosition
        {
            get
            {
                return this.notchPositions.Contains(this.Position);
            }
        }


        protected static int Advance(int val, int amount)
        {
            int inc = val + amount;

            // Avoid overflow.
            int result = (inc % 26);

            return result;
        }

        protected static int Recede(int val, int amount)
        {
            int dec = val - amount;

            // Avoid underflow.
            int result = (dec >= 0) ?
                dec :
                (dec + 26);

            return result;
        }

        public virtual int LeftInput(int val)
        {
            if (val < 0)
                throw new ArgumentException("Value cannot be lower than zero", nameof(val));
            if (val > 25)
                throw new ArgumentException("Value cannot be higher than 25", nameof(val));

            val = RotorBase.Advance(val, this.Position);

            int result = Array.IndexOf<int>(this.mapping, val);

            result = RotorBase.Recede(result, this.Position);

            return result;
        }

        public override int RightInput(int val)
        {
            if (val < 0)
                throw new ArgumentException("Value cannot be lower than zero", nameof(val));
            if (val > 25)
                throw new ArgumentException("Value cannot be higher than 25", nameof(val));

            val = RotorBase.Advance(val, this.Position);

            int result = base.RightInput(val);

            result = RotorBase.Recede(result, this.Position);

            return result;
        }
    }
}
