using UnityEngine;

public class UnityConfiguration : MonoBehaviour
{
    [SerializeField]
    private int targetFrameRate = 60;

    private void Awake()
    {
        InitializeUnity();
        Debug.Log("Unity initialization finished with no problems.");
    }

    private void InitializeUnity()
    {
        SetTargetFrameRate(targetFrameRate);
    }

    private void SetTargetFrameRate(int frameRate)
    {
        Application.targetFrameRate = frameRate;
    }
}
