using UnityEngine;

public class UnityConfiguration : MonoBehaviour
{
    private void Awake()
    {
        InitializeUnity();

        Debug.Log("Initialization finished.");
    }

    private void InitializeUnity()
    {
        SetTargetFrameRate(60);
    }

    private void SetTargetFrameRate(int frameRate)
    {
        Application.targetFrameRate = frameRate;
    }
}
