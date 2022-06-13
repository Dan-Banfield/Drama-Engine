namespace DramaEngine
{
    public static class VersionInfo
    {
        public static class CurrentVersion
        {
            public const byte Major = 1, Middle = 0, Minor = 0;

            public static string ToVersionString()
            {
                return Major.ToString() + "." + Middle.ToString() + "." + Minor.ToString();
            }
        }
    }
}
