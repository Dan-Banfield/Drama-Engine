// using System;
// using System.IO;
using UnityEngine;
// using System.Text;
// using System.Security.Cryptography;

public class EngineConfiguration : MonoBehaviour
{
    // private const string MD5_CHECKSUM = "";

    void Awake()
    {
        InitializeEngine();
    }

    private void InitializeEngine()
    {
        // Set the frame rate of the game/engine to 60 as to warrant a playable experience on all devices.
        Application.targetFrameRate = 60;

        // CheckForModifications();

        Debug.Log("Finished initialization.");
    }

    /*
    private void CheckForModifications()
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] fileChecksum = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"\" + AppDomain.CurrentDomain.FriendlyName);
            byte[] hashBytes = md5.ComputeHash(fileChecksum);

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                stringBuilder.Append(hashBytes[i].ToString("X2"));
            }

            string result = stringBuilder.ToString();

            if (result != MD5_CHECKSUM)
            {
                // TODO: Alert the user that they cannot play a modified version of the game.
            }
        }
    }
    */
}