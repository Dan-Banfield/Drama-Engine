namespace DramaEngine
{
    public static class VersionInfo
    {
        public class CurrentVersion
        {
            public const byte Major = 1, Middle = 0, Minor = 0;

            public override string ToString()
            {
                return Major.ToString() + "." + Middle.ToString() + "." + Minor.ToString();
            }
        }
    }
}
