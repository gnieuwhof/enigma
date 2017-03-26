namespace nl.gn.EnigmaCore
{
    using System;

    public class OffsetableRotor : RotorBase
    {
        private int offset;


        public OffsetableRotor(int[] mapping, int[] notchPositions, int offset)
            : base(mapping, notchPositions)
        {
            // The setter does validation.
            this.Offset = offset;
        }


        public int Offset
        {
            get
            {
                return this.offset;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Value cannot be lower than zero", nameof(offset));
                if (value > 25)
                    throw new ArgumentException("Value cannot be higher than 25", nameof(value));

                this.offset = value;
            }
        }


        public override int RightInput(int val)
        {
            if (val < 0)
                throw new ArgumentException("Value cannot be lower than zero", nameof(val));
            if (val > 25)
                throw new ArgumentException("Value cannot be higher than 25", nameof(val));

            val = Recede(val, this.Offset);

            int temp = base.RightInput(val);

            temp = Advance(temp, this.Offset);

            return temp;
        }

        public override int LeftInput(int val)
        {
            if (val < 0)
                throw new ArgumentException("Value cannot be lower than zero", nameof(val));
            if (val > 25)
                throw new ArgumentException("Value cannot be higher than 25", nameof(val));

            val = Recede(val, this.Offset);

            int temp = base.LeftInput(val);

            temp = Advance(temp, this.Offset);

            return temp;
        }
    }
}
