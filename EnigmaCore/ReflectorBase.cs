namespace nl.gn.EnigmaCore
{
    using System;

    public class ReflectorBase : Wiring
    {
        public ReflectorBase(int[] mapping)
            : base(mapping)
        {
            foreach (int val in mapping)
            {
                int temp1 = base.RightInput(val);
                int temp2 = base.RightInput(temp1);

                if (val != temp2)
                {
                    throw new ArgumentException(String.Format(
                        "Value {0} maps to {1}, but {1} maps to {2} (should map back to {0})",
                        val,
                        temp1,
                        temp2
                        )
                    );
                }
            }
        }
    }
}
