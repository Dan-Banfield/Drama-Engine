using UnityEngine;

public static class PlayerGlobals
{
    public static string PlayerName
    {
        get
        {
            return PlayerPrefs.GetString("name");
        }
        private set
        {
            PlayerPrefs.SetString("name", value);
        }
    }

    public static void SetPlayerName(string name)
    {
        PlayerName = name;
    }
}
