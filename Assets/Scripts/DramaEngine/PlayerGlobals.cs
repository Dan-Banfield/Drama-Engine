using UnityEngine;

namespace DramaEngine
{
    public static class PlayerGlobals
    {
        private static string PlayerName
        {
            get
            {
                return PlayerPrefs.GetString("name");
            }
            set
            {
                PlayerPrefs.SetString("name", value);
            }
        }

        private static string cachedPlayerName;

        public static string GetPlayerName()
        {
            if (string.IsNullOrEmpty(cachedPlayerName))
                cachedPlayerName = PlayerName;
            return cachedPlayerName;
        }

        public static void SetPlayerName(string name)
        {
            PlayerName = cachedPlayerName = name;
        }
    }
}
