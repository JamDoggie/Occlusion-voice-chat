namespace GlobalLowLevelHooks
{
    public class UniversalKey
    {
        public string KeyName { get; set; }

        public UniversalKey(string s)
        {
            KeyName = s;
        }

        public override string ToString()
        {
            return KeyName;
        }

        public override bool Equals(object? obj)
        {
            return obj is UniversalKey key &&
                   KeyName == key.KeyName;
        }

        // Operator override for == that compares the key names instead of the object.
        public static bool operator ==(UniversalKey a, UniversalKey b)
        {
            return a.KeyName == b.KeyName;
        }
        
        // Operator override for != that compares the key name instead of the object.
        public static bool operator !=(UniversalKey a, UniversalKey b)
        {
            return a.KeyName != b.KeyName;
        }
    }
}