namespace nl.gn.EnigmaCore
{
    using System;

    public class Spindle
    {
        private readonly ReflectorBase reflector;

        private readonly ThinRotor thinRotor;
        private readonly Rotor rotor1;
        private readonly Rotor rotor2;
        private readonly Rotor rotor3;


        private Spindle(ReflectorBase reflector, Rotor rotor1, Rotor rotor2, Rotor rotor3)
        {
            if (reflector == null)
                throw new ArgumentNullException(nameof(reflector));
            if (rotor1 == null)
                throw new ArgumentNullException(nameof(rotor1));
            if (rotor2 == null)
                throw new ArgumentNullException(nameof(rotor2));
            if (rotor3 == null)
                throw new ArgumentNullException(nameof(rotor3));

            this.reflector = reflector;

            this.rotor1 = rotor1;
            this.rotor2 = rotor2;
            this.rotor3 = rotor3;
        }

        // Enigma I (Wehrmacht)
        public Spindle(Reflector reflector, Rotor rotor1, Rotor rotor2, Rotor rotor3)
            : this((ReflectorBase)reflector, rotor1, rotor2, rotor3)
        {
        }

        // M4 (Kriegsmarine)
        public Spindle(ThinReflector thinReflector, ThinRotor thinRotor,
            Rotor rotor1, Rotor rotor2, Rotor rotor3
            )
            : this((ReflectorBase)thinReflector, rotor1, rotor2, rotor3)
        {
            if (thinRotor == null)
                throw new ArgumentNullException(nameof(thinRotor));

            this.thinRotor = thinRotor;
        }


        public int Input(int val)
        {
            /*
            // Normal odometer style stepping (Enigma G).
            {
                if (this.rotor3.IsNotchPosition)
                {
                    if (this.rotor2.IsNotchPosition)
                    {
                        ++this.rotor1.Position;
                    }

                    ++this.rotor2.Position;
                }

                // This rotor steps every keystroke.
                ++this.rotor3.Position;
            }
            */

            // Double stepping.
            {
                if (this.rotor3.IsNotchPosition)
                {
                    ++this.rotor2.Position;
                }
                else if (this.rotor2.IsNotchPosition)
                {
                    // In this case, the second rotor stepped with the
                    // previous keystroke, and will do now again.
                    // Hence, the double stepping.
                    ++this.rotor2.Position;
                    ++this.rotor1.Position;
                }

                // This rotor steps every keystroke.
                ++this.rotor3.Position;
            }

            int t1 = this.rotor3.RightInput(val);

            int t2 = this.rotor2.RightInput(t1);

            int t3 = this.rotor1.RightInput(t2);

            if (this.thinRotor != null)
            {
                // Enigma M4
                t3 = this.thinRotor.RightInput(t3);
            }

            int t4 = this.reflector.RightInput(t3);

            if (this.thinRotor != null)
            {
                // Enigma M4
                t4 = this.thinRotor.LeftInput(t4);
            }

            int t5 = this.rotor1.LeftInput(t4);

            int t6 = this.rotor2.LeftInput(t5);

            int t7 = this.rotor3.LeftInput(t6);

            return t7;
        }
    }
}
