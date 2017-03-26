namespace nl.gn.EnigmaCore
{
    using System;
    using System.Collections.Generic;

    public class Plugboard
    {
        private readonly Spindle spindle;
        private readonly IDictionary<int, int> swappings =
            new Dictionary<int, int>();


        public Plugboard(Spindle spindle, IDictionary<int, int> swappings)
        {
            if (spindle == null)
                throw new ArgumentNullException(nameof(spindle));
            if (swappings == null)
                throw new ArgumentNullException(nameof(swappings));

            // We could check the length of crossings, as an
            // Enigma machine has 10 cables.
            // On the other hand, 11 cables is more (most) secure and
            // we can use a cable from another machine.
            // So, the check is omitted.

            var temp = new List<int>();
            foreach (KeyValuePair<int, int> kv in swappings)
            {
                if (kv.Key < 0)
                    throw new ArgumentException("Dictionary cannot contain keys lower than zero", nameof(swappings));
                if (kv.Key > 25)
                    throw new ArgumentException("Dictionary cannot contain keys higher than 25", nameof(swappings));
                if (kv.Value < 0)
                    throw new ArgumentException("Dictionary cannot contain values lower than zero", nameof(swappings));
                if (kv.Value > 25)
                    throw new ArgumentException("Dictionary cannot contain values higher than 25", nameof(swappings));
                if (temp.Contains(kv.Key))
                    throw new ArgumentException("Value occurs multiple times", nameof(swappings));
                if (temp.Contains(kv.Value))
                    throw new ArgumentException(
                        String.Format("Value '{0}' occurs multiple times", Convert.ToChar(kv.Value + 'A')),
                        nameof(swappings)
                        );

                temp.Add(kv.Key);
                temp.Add(kv.Value);
            }

            this.spindle = spindle;

            foreach (KeyValuePair<int, int> kv in swappings)
            {
                this.swappings.Add(kv.Key, kv.Value);

                // Reverse swapping.
                this.swappings.Add(kv.Value, kv.Key);
            }
        }


        private int SwapIfNecessary(int val)
        {
            if (this.swappings.ContainsKey(val))
            {
                return this.swappings[val];
            }

            // No swapping.
            return val;
        }

        public int Get(int val)
        {
            val = this.SwapIfNecessary(val);

            int result = this.spindle.Input(val);

            result = this.SwapIfNecessary(result);

            return result;
        }
    }
}
