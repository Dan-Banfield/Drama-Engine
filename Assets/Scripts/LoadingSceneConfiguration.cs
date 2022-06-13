using UnityEngine;
using DramaEngine;
using System.Collections;

public class LoadingSceneConfiguration : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingUI;

    [SerializeField] 
    TMPro.TextMeshProUGUI versionLabel;

    void Awake()
    {
        InitializeScene();
    }

    private void InitializeScene()
    {
        UpdateVersionLabel();
        StartCoroutine(LoadingExample());
    }

    private void UpdateVersionLabel()
    {
        versionLabel.text = new VersionInfo.CurrentVersion().ToString();
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
