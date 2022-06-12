using System.Collections;
using UnityEngine;

public class LoadingSceneConfiguration : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingUI;

    void Awake()
    {
        InitializeScene();
    }

    private void InitializeScene()
    {
        StartCoroutine(LoadingExample());
    }

    private IEnumerator LoadingExample()
    {
        ShowLoadingUI();
        yield return new WaitForSeconds(5);
        CloseLoadingUI();
    }

    private void ShowLoadingUI()
    {
        loadingUI.SetActive(true);
    }

    private void CloseLoadingUI()
    {
        loadingUI.SetActive(false);
    }
}
